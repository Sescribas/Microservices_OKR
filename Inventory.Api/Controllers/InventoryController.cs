using Inventory.Api.Models;
using Inventory.Services.EventHandler.Commands;
using Inventory.Services.EventHandler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OKR.Common.Domain;
using OKR.Common.Domain.Dtos.ProductStockDto;
using OKR.Common.Domain.Dtos.SellDto;
using OKR.Common.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Net.Mime;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private ISellCollection _sellCollection;
        private IMediator _mediator;

        public InventoryController(ISellCollection sellCollection,IMediator mediator)
        {
            _sellCollection = sellCollection;
            _mediator = mediator;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de ventas.")]
        public async Task<List<GetSellDtoResponse>> Get()
        {
            var response = await _mediator.Send(new GetAllSellQuery());

            return response;
        }

        [HttpGet("get/{sell_id}")]
        [Description("Obtiene una venta.")]
        public async Task<IActionResult> GetById([FromRoute(Name = "sell_id")] string sellId)
        {
            var response = await _mediator.Send(new GetByIdSellQuery(sellId));

            return Ok(response);
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Se crea una venta.", Tags = new[] { "Sell" })]
        [ProducesResponseType(typeof(SellCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] SellCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        //[HttpPut("update/{productStock_id}")]
        //[SwaggerOperation(Summary = "Se modifica un producto stock.", Tags = new[] { "User" })]
        //[ProducesResponseType(typeof(ProductStockUpdateCommand), StatusCodes.Status201Created)]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Update([FromBody] ProductStockUpdateCommand command, [FromRoute(Name = "productStock_id")] int productId)
        //{
        //    command.Id = productId;
        //    var result = await _mediator.Send(command);

        //    return result.Success ? Ok() : BadRequest(result);
        //}

        //[HttpDelete("delete/{productStock_id}")]
        //[SwaggerOperation(Summary = "Se elimina un producto stock.", Tags = new[] { "ProductStock" })]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Delete([FromRoute(Name = "productStock_id")] int productId)
        //{
        //    var result = await _mediator.Send(new ProductStockDeleteCommand(productId));

        //    return result.Success ? Ok() : BadRequest(result);
        //}
    }
}
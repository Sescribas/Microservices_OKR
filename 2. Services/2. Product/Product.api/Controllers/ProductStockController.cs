using MediatR;
using Microsoft.AspNetCore.Mvc;
using OKR.Common.Domain.Dto_s;
using OKR.Common.Domain.Dtos.ProductStockDto;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCommand;
using Product.Services.EventHandlers.Commands.ProductStockCommand;
using Product.Services.EventHandlers.Queries.ProductStockQueries;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Net.Mime;

namespace Product.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStockController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductStockService _productStockService;
        private readonly IProductService _productService;

        public ProductStockController(IMediator mediator, IProductService productService, IProductStockService productStockService)
        {
            _mediator = mediator;
            _productService = productService;
            _productStockService = productStockService;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de productos stock.")]
        public async Task<List<GetProductStockDtoResponse>> Get()
        {
            var response = await _mediator.Send(new GetAllProductStockQuery());

            return response;
        }

        [HttpGet("get/{product_id}")]
        [Description("Obtiene un listado de productos stock.")]
        public async Task<IActionResult> GetById([FromRoute(Name = "product_id")] int productId)
        {
            var response = await _mediator.Send(new GetByIdProductStockQuery(productId));

            return Ok(response);
        }
      
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Se crea un producto stock.", Tags = new[] { "Product" })]
        [ProducesResponseType(typeof(ProductStockCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] ProductStockCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpPut("update/{productStock_id}")]
        [SwaggerOperation(Summary = "Se modifica un producto stock.", Tags = new[] { "User" })]
        [ProducesResponseType(typeof(ProductStockUpdateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Update([FromBody] ProductStockUpdateCommand command, [FromRoute(Name = "productStock_id")] int productId)
        {
            command.Id = productId;
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        //[HttpDelete("delete/{productStock_id}")]
        //[SwaggerOperation(Summary = "Se elimina un producto stock.", Tags = new[] { "ProductStock" })]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Delete([FromRoute(Name = "productStock_id")] int productId)
        //{
        //    var result = await _mediator.Send(new ProductStockDeleteCommand(productId));

        //    return result.Success ? Ok() : BadRequest(result);
        //}

        private List<GetProductStockDtoResponse> MapProducts(List<OKR.Common.Domain.ProductStock> products)
        {
            List<GetProductStockDtoResponse> result = new List<GetProductStockDtoResponse>();
            foreach (var product in products)
            {
                result.Add(new GetProductStockDtoResponse
                {
                    Id = product.Id,
                    ProductId = product.ProductId,
                    SellingPrice = product.SellingPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    LastUpdated = product.LastUpdated,
                    Currency = product.Currency,
                });
            }
            return result;
        }
    }
}

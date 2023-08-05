using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;
using System.Net.Mime;
using MediatR;
using OKR.Common.Domain;
using OKR.Common.Services;
using OKR.Common.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Product.Services.EventHandlers.Commands;

namespace Product.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductController( IMediator mediator, IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de productos.")]
        public IEnumerable<OKR.Common.Domain.Product> Get()
        {
            var users = _productService.GetProducts();

            return users;
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Se crea un producto.", Tags = new[] { "Product" })]
        [ProducesResponseType(typeof(ProductCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] ProductCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpPut("update/{product_id}")]
        [SwaggerOperation(Summary = "Se modifica un usuario.", Tags = new[] { "User" })]
        [ProducesResponseType(typeof(ProductUpdateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateCommand command, [FromRoute(Name = "product_id")] int productId)
        {
            command.Id = productId;
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpDelete("delete/{product_id}")]
        [SwaggerOperation(Summary = "Se elimina un usuario.", Tags = new[] { "User" })]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Delete([FromRoute(Name = "product_id")] int productId)
        {
            var result = await _mediator.Send(new ProductDeleteCommand(productId));

            return result.Success ? Ok() : BadRequest(result);
        }

    }
}
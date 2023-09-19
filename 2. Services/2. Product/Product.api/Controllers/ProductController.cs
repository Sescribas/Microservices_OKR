using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;
using System.Net.Mime;
using MediatR;
using OKR.Common.Domain;
using OKR.Common.Services;
using OKR.Common.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Product.Services.EventHandlers.Commands.ProductCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using OKR.Common.Domain.Dto_s;

namespace Product.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;

        public ProductController( IMediator mediator,IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de productos.")]
        public IEnumerable<GetAllProductsDtoResponse> Get()
        {

            var product = _productService.GetProducts();

            var response = MapProducts(product);
            return response;
        }

        [HttpGet("get/{product_id}")]
        [Description("Obtiene un listado de productos.")]
        public IEnumerable<GetAllProductsDtoResponse> GetById([FromRoute(Name = "product_id")] int productId)
        {

            var product = _productService.GetById(productId);

            if (product is null)
                return null;

            var response = MapProducts(new List<OKR.Common.Domain.Product> { product });
            return response;
        }

        [HttpGet("get/category/{category_id}")]
        [Description("Obtiene un listado de productos.")]
        public IEnumerable<GetAllProductsDtoResponse> GetByCategoryId([FromRoute(Name = "category_id")] int categoryId)
        {

            var products = _productService.GetProductsByCategoryId(categoryId);

            if (products is null)
                return null;

            var response = MapProducts(products);
            return response;
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
        [SwaggerOperation(Summary = "Se modifica un producto.", Tags = new[] { "Product" })]
        [ProducesResponseType(typeof(ProductUpdateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateCommand command, [FromRoute(Name = "product_id")] int productId)
        {
            command.Id = productId;
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpDelete("delete/{product_id}")]
        [SwaggerOperation(Summary = "Se elimina un producto.", Tags = new[] { "Product" })]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Delete([FromRoute(Name = "product_id")] int productId)
        {
            var result = await _mediator.Send(new ProductDeleteCommand(productId));

            return result.Success ? Ok() : BadRequest(result);
        }

        private List<GetAllProductsDtoResponse> MapProducts(List<OKR.Common.Domain.Product> products)
        {
            List<GetAllProductsDtoResponse> result = new List<GetAllProductsDtoResponse>();
            foreach (var product in products)
            {
                result.Add(new GetAllProductsDtoResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Brand = product.Brand,
                    ExpirationDate = product.ExpirationDate,
                    FabricationDate = product.FabricationDate,
                    CategoryId = product.CategoryId,
                    NameCategory = product.Category.Name,
                    DescriptionCategory = product.Category.Description

                });
            }
            return result;
        }

    }
}
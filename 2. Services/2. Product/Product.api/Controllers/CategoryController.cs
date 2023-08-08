using MediatR;
using Microsoft.AspNetCore.Mvc;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCategoryCommand;
using Product.Services.EventHandlers.Commands.ProductCommand;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Net.Mime;

namespace Product.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICategoryService _categoryService;

        public CategoryController(IMediator mediator, ICategoryService categoryService)
        {
            _mediator = mediator;
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de categorias.")]
        public IEnumerable<OKR.Common.Domain.Category> Get()
        {
            var users = _categoryService.GetCategories();

            return users;
        }

        [HttpPost("create")]
        [SwaggerOperation(Summary = "Se crea una categoria.", Tags = new[] { "Category" })]
        [ProducesResponseType(typeof(CategoryCreateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpPut("update/{category_id}")]
        [SwaggerOperation(Summary = "Se modifica una categoria.", Tags = new[] { "Category" })]
        [ProducesResponseType(typeof(CategoryUpdateCommand), StatusCodes.Status201Created)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateCommand command, [FromRoute(Name = "category_id")] int categoryId)
        {
            command.Id = categoryId;
            var result = await _mediator.Send(command);

            return result.Success ? Ok() : BadRequest(result);
        }

        [HttpDelete("delete/{category_id}")]
        [SwaggerOperation(Summary = "Se elimina una categoria.", Tags = new[] { "User" })]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> Delete([FromRoute(Name = "category_id")] int categoryId)
        {
            var result = await _mediator.Send(new CategoryDeleteCommand(categoryId));

            return result.Success ? Ok() : BadRequest(result);
        }
    }
}

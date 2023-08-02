using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.ComponentModel;
using System.Net.Mime;
using MediatR;
using OKR.Common.Domain;
using OKR.Common.Services;
using OKR.Common.Services.Interfaces;

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

        //[HttpGet("getall")]
        //[Description("Obtiene un listado de productos.")]
        //public IEnumerable<Product> Get()
        //{
        //    var users = _productService.GetProducts();

        //    return users;
        //}

        //[HttpPost("create")]
        //[SwaggerOperation(Summary = "Crea un nuevo usuario.", Tags = new[] { "User" })]
        //[ProducesResponseType(typeof(UserCreateCommand), StatusCodes.Status201Created)]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Create([FromBody] UserCreateCommand command)
        //{
        //    var result = await _mediator.Send(command);

        //    return result.Success ? Ok() : BadRequest(result);
        //}

        //[HttpPut("update/{user_id}")]
        //[SwaggerOperation(Summary = "Se modifica un usuario.", Tags = new[] { "User" })]
        //[ProducesResponseType(typeof(UserUpdateCommand), StatusCodes.Status201Created)]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Update([FromBody] UserUpdateCommand command, [FromRoute(Name = "user_id")] int userId)
        //{
        //    command.Id = userId;
        //    var result = await _mediator.Send(command);

        //    return result.Success ? Ok() : BadRequest(result);
        //}

        //[HttpDelete("delete/{user_id}")]
        //[SwaggerOperation(Summary = "Se elimina un usuario.", Tags = new[] { "User" })]
        //[Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        //public async Task<IActionResult> Delete([FromRoute(Name = "user_id")] int userId)
        //{
        //    var result = await _mediator.Send(new UserDeleteCommand(userId));

        //    return result.Success ? Ok() : BadRequest(result);
        //}

    }
}
using Inventory.Services.EventHandler.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OKR.Common.Domain.Dtos.SellDto;
using OKR.Common.Repositories.Interfaces;
using System.ComponentModel;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController
    {

        private ISellCollection _sellCollection;
        private IMediator _mediator;

        public InventoryController(ISellCollection sellCollection, IMediator mediator)
        {
            _sellCollection = sellCollection;
            _mediator = mediator;
        }

        [HttpGet("getall")]
        [Description("Obtiene un listado de usuarios.")]
        public async Task<List<GetSellDtoResponse>> Get()
        {
            var response = await _mediator.Send(new GetAllSellQuery());

            return response;
        }
    }
}

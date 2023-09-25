using Inventory.Api.Models;
using Microsoft.AspNetCore.Mvc;
using OKR.Common.Domain;
using OKR.Common.Repositories.Interfaces;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private ISellCollection _sellCollection;

        public InventoryController(ISellCollection sellCollection)
        {
            _sellCollection = sellCollection;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSells()
        {
            return Ok(await _sellCollection.GetAllSell());
        }

        [HttpPost("api/create")]
        public async Task<IActionResult> CreateSell([FromBody] SellViewModel sellViewModel)
        {
            var sell = new Sell
            {
                Id = sellViewModel.Id,
                SellDetailId = sellViewModel.SellDetailId,
                TotalAmount = sellViewModel.TotalAmount,
                UserId = sellViewModel.UserId,
                BuyDate = sellViewModel.BuyDate
            };
            await _sellCollection.InsertSell(sell);

            return Ok();
        }
    }
}
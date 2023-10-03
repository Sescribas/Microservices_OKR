using MediatR;
using MongoDB.Bson;
using Newtonsoft.Json;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Services.EventHandler.Commands.Sell
{
    public class SellCreateCommand : IRequest<BaseResult<string>>
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }

        [JsonProperty("sellDetailId")]
        public string SellDetailId { get; set; }

        [JsonProperty("userId")]
        public decimal UserId { get; set; }

        [JsonProperty("totalAmount")]
        public double TotalAmount { get; set; }

        [JsonProperty("buyDate")]
        public DateTime BuyDate { get; set; }
    }
}

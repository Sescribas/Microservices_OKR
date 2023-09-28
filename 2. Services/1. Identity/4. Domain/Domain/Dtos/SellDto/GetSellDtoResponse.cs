using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OKR.Common.Domain.Dtos.SellDto
{
    public class GetSellDtoResponse
    {
        [JsonProperty("id")]
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

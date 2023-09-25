using MongoDB.Bson;
using Newtonsoft.Json;

namespace Inventory.Api.Models
{
    public class SellViewModel
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

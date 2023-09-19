using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain.Dtos.ProductStockDto
{
    public class GetAllProductStockDtoResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("sellingPrice")]
        public decimal SellingPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        [JsonProperty("currency")]

        public string Currency { get; set; }


        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

    }
}

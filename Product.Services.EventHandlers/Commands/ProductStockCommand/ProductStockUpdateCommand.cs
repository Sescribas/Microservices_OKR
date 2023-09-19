using MediatR;
using Newtonsoft.Json;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Commands.ProductStockCommand
{
    public class ProductStockUpdateCommand : IRequest<BaseResult<string>>
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
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

        [JsonIgnore]
        public DateTime LastUpdated { get; set; }


    }
}

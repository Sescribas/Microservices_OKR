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
    public class ProductStockCreateCommand : IRequest<BaseResult<string>>
    {
        [Required]
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [Required]
        [JsonProperty("sellingPrice")]
        public decimal SellingPrice { get; set; }

        [Required]
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

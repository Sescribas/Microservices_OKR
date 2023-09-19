using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using OKR.Common.Results;

namespace Product.Services.EventHandlers.Commands.ProductStockCommand
{
    public class ProductStockDeleteCommand : IRequest<BaseResult<string>>
    {
        public ProductStockDeleteCommand(int productId)
        {
            Id = productId;
        }

        [JsonIgnore]
        public int Id { get; set; }

    }
}

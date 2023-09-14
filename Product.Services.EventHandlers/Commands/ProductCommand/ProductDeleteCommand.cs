using MediatR;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Commands.ProductCommand
{
    public class ProductDeleteCommand : IRequest<BaseResult<string>>
    {
        public ProductDeleteCommand(int productId)
        {
            Id = productId;
        }

        [JsonIgnore]
        public int Id { get; set; }
    }
}

using MediatR;
using Newtonsoft.Json;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Commands.ProductCategoryCommand
{
    public class CategoryUpdateCommand : IRequest<BaseResult<string>>
    {
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}

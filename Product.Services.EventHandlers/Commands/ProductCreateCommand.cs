﻿using MediatR;
using Newtonsoft.Json;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Commands
{
    public class ProductCreateCommand : IRequest<BaseResult<string>>
    {

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("FabricationDate")]
        public DateTime FabricationDate { get; set; }

        [JsonProperty("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}

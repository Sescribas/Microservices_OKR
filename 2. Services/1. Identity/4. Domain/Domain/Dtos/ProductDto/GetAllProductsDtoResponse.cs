using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain.Dto_s
{
    public class GetAllProductsDtoResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]

        public string Description { get; set; }

        [JsonProperty("brand")]

        public string Brand { get; set; }

        [JsonProperty("fabricationDate")]

        public DateTime FabricationDate { get; set; }

        [JsonProperty("expirationDate")]

        public DateTime ExpirationDate { get; set; }

        [JsonProperty("nameCategory")]

        public string NameCategory { get; set; }
        [JsonProperty("descriptionCategory")]

        public string DescriptionCategory { get; set; }


    }
}

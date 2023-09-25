using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain
{
    public class SellDetail
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string SellDetailId { get; set; }

        public string ProductsId { get; set; }

        public string Stocks { get; set; }

        public DateTime BuyDate { get; set; }
    }
}

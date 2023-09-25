using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain
{
    public class Sell
    {
        [BsonId]
        public ObjectId Id { get;set; }

        /// <summary>
        /// Se encargara de listar los productos y las cantidades por producto
        /// </summary>
        public string SellDetailId { get; set; }

        public decimal UserId { get; set; }

        public double TotalAmount { get; set; }

        public DateTime BuyDate { get; set; }
    }
}

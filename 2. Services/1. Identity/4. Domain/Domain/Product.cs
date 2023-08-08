using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public Category ProductCategory { get; set; }

        //SellProduct
        //id, idproducto, stock, price

        //SellProductDetail
        //id, idSell, idProducto, amount, SellDate 
        // double Price { get; set; }
        //public int Stock { get; set; }

        //sell
        //

    }
}

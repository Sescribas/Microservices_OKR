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
        public double Price { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public ProductType ProductType { get; set; }
    }
}

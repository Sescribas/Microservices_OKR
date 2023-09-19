using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Domain
{
    public class ProductStock
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Currency { get; set; }

        public Product Product { get; set; }
    }
}

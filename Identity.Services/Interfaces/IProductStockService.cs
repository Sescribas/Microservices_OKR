using OKR.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Services.Interfaces
{
    public interface IProductStockService
    {
        void Create(ProductStock product);
        void Delete(ProductStock product);
        ProductStock? GetById(int id);
        List<ProductStock> GetProducts();
        void Update(ProductStock product);
    }
}

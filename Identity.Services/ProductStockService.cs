using OKR.Common.Domain;
using OKR.Common.Repositories.Interfaces;
using OKR.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Services
{
    public class ProductStockService : IProductStockService
    {
        private readonly IProductStockRepository _productStockRepository;

        public ProductStockService(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }

        public List<ProductStock> GetProducts()
        {
            var products = _productStockRepository.GetProducts();
            return products;
        }

        public ProductStock? GetById(int id)
        {
            var product = _productStockRepository.GetById(id);
            return product;
        }

        public void Create(ProductStock product)
        {
            _productStockRepository.Create(product);
        }

        public void Update(ProductStock product)
        {
            _productStockRepository.Update(product);
        }

        public void Delete(ProductStock product)
        {
            _productStockRepository.Delete(product);
        }
    }
}

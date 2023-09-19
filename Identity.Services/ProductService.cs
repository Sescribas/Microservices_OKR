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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.GetProducts();
            return products;
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            var products = _productRepository.GetByCategoryId(id);
            return products;
        }

        public Product? GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }
    }
}

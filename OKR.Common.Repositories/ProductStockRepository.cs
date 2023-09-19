using Microsoft.EntityFrameworkCore;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.ProductDbContext;
using OKR.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Repositories
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly ProductDBContext _context;
        public ProductStockRepository(ProductDBContext context)
        {
            _context = context;
        }

        public List<ProductStock> GetProducts()
        {
            return _context.ProductStocks.Include(x => x.Product).ToList();
        }
        public ProductStock? GetById(int id)
        {
            return _context.ProductStocks.Include(x => x.Product).FirstOrDefault(x => x.Id == id);
        }

        public void Create(ProductStock product)
        {
            _context.ProductStocks.AddAsync(product);
            _context.SaveChanges();
        }

        public void Update(ProductStock product)
        {
            _context.ProductStocks.Update(product);
            _context.SaveChanges();
        }

        public void Delete(ProductStock product)
        {
            _context.ProductStocks.Remove(product);
            _context.SaveChanges();
        }
    }
}

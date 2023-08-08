using Microsoft.EntityFrameworkCore;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.IdentityDbContext;
using OKR.Common.Persistence.Database.ProductDbContext;
using OKR.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;


        public ProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
        public Product? GetById(int id)
        {
            return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public void Create(Product product)
        {
            _context.Products.AddAsync(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

using OKR.Common.Domain;
using OKR.Common.Persistence.Database.ProductDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDBContext _context;


        public CategoryRepository(ProductDBContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Category category)
        {
            _context.Categories.AddAsync(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}

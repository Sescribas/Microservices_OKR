using OKR.Common.Domain;
using OKR.Common.Repositories;
using OKR.Common.Repositories.Interfaces;
using OKR.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetCategories()
        {
            var products = _categoryRepository.GetCategories();
            return products;
        }

        public Category? GetById(int id)
        {
            var product = _categoryRepository.GetById(id);
            return product;
        }

        public void Create(Category category)
        {
            _categoryRepository.Create(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }
    }
}

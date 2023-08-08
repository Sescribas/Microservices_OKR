using OKR.Common.Domain;

namespace OKR.Common.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Delete(Category category);
        Category? GetById(int id);
        List<Category> GetCategories();
        void Update(Category category);
    }
}
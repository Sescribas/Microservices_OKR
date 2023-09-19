using OKR.Common.Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(Product product);
        Product? GetById(int id);
        List<Product> GetProducts();
        List<Product> GetByCategoryId(int categoryId);
        void Update(Product product);
    }
}
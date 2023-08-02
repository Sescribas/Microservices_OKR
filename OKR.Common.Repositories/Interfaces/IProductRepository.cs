using OKR.Common.Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Delete(Product product);
        Product? GetById(int id);
        List<Product> GetProducts();
        void Update(Product product);
    }
}
using OKR.Common.Domain;

namespace OKR.Common.Services.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        void Delete(Product product);
        Product? GetById(int id);
        List<Product> GetProducts();
        void Update(Product product);
    }
}
using OKR.Common.Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IProductStockRepository
    {
        List<ProductStock> GetProducts();
        ProductStock? GetById(int id);
        void Create(ProductStock productStok);
        void Update(ProductStock productStok);
        void Delete(ProductStock productStok);
    }
}
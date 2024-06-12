using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithSupplierAsync();
    Task<IEnumerable<Product>> GetAllBySupplierAsync(Guid supplierId);
    Task<Product?> GetWithSupplierAsync(Guid id);
}

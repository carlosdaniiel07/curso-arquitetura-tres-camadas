using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier?> GetWithAddressAsync(Guid id);
    Task<Supplier?> GetWithAddressAndProductsAsync(Guid id);
    Task<Address?> GetAddressBySupplierAsync(Guid supplierId);
    Task DeleteAddressAsync(Guid addressId);
}

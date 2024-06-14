using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class SupplierRepository(ApplicationDbContext dbContext) : Repository<Supplier>(dbContext), ISupplierRepository
{
    public async Task<Address?> GetAddressBySupplierAsync(Guid supplierId)
    {
        return await DbContext
            .Addresses
            .SingleOrDefaultAsync(address => address.SupplierId == supplierId);
    }

    public async Task<Supplier?> GetWithAddressAndProductsAsync(Guid id)
    {
        return await DbSet
            .Include(supplier => supplier.Address)
            .Include(supplier => supplier.Products)
            .SingleOrDefaultAsync(supplier => supplier.Id == id);
    }

    public async Task<Supplier?> GetWithAddressAsync(Guid id)
    {
        return await DbSet
            .Include(supplier => supplier.Address)
            .SingleOrDefaultAsync(supplier => supplier.Id == id);
    }

    public async Task DeleteAddressAsync(Guid addressId)
    {
        await DbContext
            .Addresses
            .Where(address => address.Id == addressId)
            .ExecuteDeleteAsync();
        await SaveChangesAsync();
    }
}

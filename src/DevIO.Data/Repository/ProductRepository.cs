using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class ProductRepository(ApplicationDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllBySupplierAsync(Guid supplierId)
    {
        return await GetAllAsync(product => product.SupplierId == supplierId);
    }

    public async Task<IEnumerable<Product>> GetAllWithSupplierAsync()
    {
        return await DbSet
            .Include(product => product.Supplier)
            .ToListAsync();
    }

    public async Task<Product?> GetWithSupplierAsync(Guid id)
    {
        return await DbSet
            .Include(product => product.Supplier)
            .SingleOrDefaultAsync(product =>  product.Id == id);
    }
}

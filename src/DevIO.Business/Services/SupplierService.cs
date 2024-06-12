using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class SupplierService : BaseService, ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(INotifier notifier, ISupplierRepository repository) : base(notifier)
    {
        _repository = repository;
    }

    public async Task AddAsync(Supplier supplier)
    {
        var isValid = Validate(new SupplierValidation(), supplier) && Validate(new AddressValidation(), supplier.Address);

        if (!isValid)
            return;

        var alreadyExists = (await _repository.GetAllAsync(s => s.Document == supplier.Document)).Any();

        if (alreadyExists)
        {
            Notify($"Supplier with document '{supplier.Document}' already exists");
            return;
        }

        await _repository.AddAsync(supplier);
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        var isValid = Validate(new SupplierValidation(), supplier) && Validate(new AddressValidation(), supplier.Address);

        if (!isValid)
            return;

        var alreadyExists = (await _repository.GetAllAsync(s => s.Document == supplier.Document && s.Id != supplier.Id)).Any();

        if (alreadyExists)
        {
            Notify($"Supplier with document '{supplier.Document}' already exists");
            return;
        }

        await _repository.UpdateAsync(supplier);
    }

    public async Task RemoveAsync(Guid id)
    {
        var supplier = await _repository.GetWithAddressAndProductsAsync(id);

        if (supplier == null)
        {
            Notify("Supplier not exists");
            return;
        }

        var hasProducts = supplier.Products.Any();

        if (hasProducts)
        {
            Notify("Supplier still has products");
            return;
        }

        var address = await _repository.GetAddressBySupplierAsync(id);

        if (address != null)
            await _repository.DeleteAddressAsync(address.Id);

        await _repository.DeleteAsync(id);
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}

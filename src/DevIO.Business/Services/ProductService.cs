using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(INotifier notifier, IProductRepository repository) : base(notifier)
    {
        _repository = repository;
    }

    public async Task AddAsync(Product product)
    {
        var isValid = Validate(new ProductValidation(), product);

        if (!isValid)
            return;

        await _repository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        var isValid = Validate(new ProductValidation(), product);

        if (!isValid)
            return;

        await _repository.UpdateAsync(product);
    }

    public async Task RemoveAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}

using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("/api/v1/products")]
public class ProductController : MainController
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;

    public ProductController(
        IMapper mapper,
        INotifier notifier,
        IProductService productService,
        IProductRepository productRepository
    ) : base(mapper, notifier)
    {
        _productService = productService;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllAsync()
    {
        var products = await _productRepository.GetAllWithSupplierAsync();
        var result = _mapper.Map<IEnumerable<ProductViewModel>>(products);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> SaveAsync([FromBody] ProductViewModel productViewModel)
    {
        var product = _mapper.Map<Product>(productViewModel);
        await _productService.AddAsync(product);

        return CustomResponse();
    }
}

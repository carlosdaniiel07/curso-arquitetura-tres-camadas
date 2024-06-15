using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ProductViewModel, Product>()
            .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(_ => true))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<Product, ProductViewModel>();
    }
}

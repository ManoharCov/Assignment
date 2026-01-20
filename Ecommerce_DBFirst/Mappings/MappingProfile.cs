using AutoMapper;
using Ecommerce_DBFirst.Models;
using Ecommerce_DBFirst.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductListVM>()
            .ForMember(d => d.CategoryName,
                o => o.MapFrom(s => s.Category.CategoryName));
    }
}

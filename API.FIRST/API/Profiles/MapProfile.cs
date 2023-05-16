using API.Apps.AdminApi.DTOs.BrandDTOs;
using API.Apps.AdminApi.DTOs.ProductDTOs;
using API.Apps.ClientApi.DTOs.ProductDTOs;
using AutoMapper;
using Core.Entites;

namespace API.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, CProductGetAllDTO>();
            CreateMap<Product, CProductGetDTO>();
            CreateMap<Brand,BrandInProductGetDto >();
            CreateMap<BrandDTO, Brand>();
            CreateMap<Brand, BrandGetDTO>();
            CreateMap<Brand, BrandGetAllDTO>();
            CreateMap<Product, ProductGetAllDTO>()
                .ForMember(d => d.DiscountedPrice, s => s.MapFrom(x => (x.SalePrice * (x.DiscountPercent) / 100)));
            CreateMap<Product, ProductGetDTO>()
                .ForMember(d => d.DiscountedPrice, s => s.MapFrom(x => (x.SalePrice * (x.DiscountPercent) / 100)));
            CreateMap<ProductDTO, Product>();
        }
    }
}

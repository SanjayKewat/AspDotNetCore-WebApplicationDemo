using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    //here Profile is class under AutoMapper namespace
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Product model map to ProductToReturnDto model
            CreateMap<Product, ProductToReturnDto>()
            //set foregin table name value,
            // ProductBrand value set from ProductBrand.Name
                .ForMember(b => b.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(b => b.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(b => b.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
} 
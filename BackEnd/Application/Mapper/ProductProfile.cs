using AutoMapper;
using Service.Catalog.API.Application.Dtos;
using Service.Catalog.API.Models;

namespace Service.Catalog.API.Application.Mapper
{
    
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<AddProductDto,Product>();
            CreateMap<EditProductDto,Product>();
            CreateMap<Category, CategoryDto>();
        }
    }
    
}
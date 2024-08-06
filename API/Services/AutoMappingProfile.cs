using API.DTOs.Products;
using AutoMapper;
using DOMAIN.Models;

namespace API.Services
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}

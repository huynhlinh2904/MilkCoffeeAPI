using AutoMapper;

namespace MilkCoffeeAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Entities.Product, Models.Response.ProductResponse>().ReverseMap();
            CreateMap<Entities.Category, Models.Response.CategoryResponse>().ReverseMap();
        }
    }
}

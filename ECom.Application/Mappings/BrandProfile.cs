using ECom.Application.Features.Brands.Commands.Create;
using ECom.Application.Features.Brands.Queries.GetAllCached;
using ECom.Application.Features.Brands.Queries.GetById;
using ECom.Domain.Entities.Catalog;
using AutoMapper;

namespace ECom.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}
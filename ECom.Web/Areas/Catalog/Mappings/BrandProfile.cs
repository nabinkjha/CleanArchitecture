using ECom.Application.Features.Brands.Commands.Create;
using ECom.Application.Features.Brands.Commands.Update;
using ECom.Application.Features.Brands.Queries.GetAllCached;
using ECom.Application.Features.Brands.Queries.GetById;
using ECom.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ECom.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}
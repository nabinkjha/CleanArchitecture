using ECom.Application.Features.Products.Commands.Create;
using ECom.Application.Features.Products.Commands.Update;
using ECom.Application.Features.Products.Queries.GetAllCached;
using ECom.Application.Features.Products.Queries.GetById;
using ECom.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ECom.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}
using ECom.Application.Features.Products.Commands.Create;
using ECom.Application.Features.Products.Queries.GetAllCached;
using ECom.Application.Features.Products.Queries.GetAllPaged;
using ECom.Application.Features.Products.Queries.GetById;
using ECom.Domain.Entities.Catalog;
using AutoMapper;

namespace ECom.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}
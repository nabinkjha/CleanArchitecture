using ECom.Application.Features.PaymentDetails.Commands.Create;
using ECom.Application.Features.PaymentDetails.Queries.GetAllCached;
using ECom.Application.Features.PaymentDetails.Queries.GetAllPaged;
using ECom.Application.Features.PaymentDetails.Queries.GetById;
using ECom.Domain.Entities;
using AutoMapper;

namespace ECom.Application.Mappings
{
    internal class PaymentDetailProfile : Profile
    {
        public PaymentDetailProfile()
        {
            CreateMap<CreatePaymentDetailCommand, PaymentDetail>().ReverseMap();
            CreateMap<GetPaymentDetailByIdResponse, PaymentDetail>().ReverseMap();
            CreateMap<GetAllPaymentDetailsCachedResponse, PaymentDetail>().ReverseMap();
            CreateMap<GetAllPaymentDetailsResponse, PaymentDetail>().ReverseMap();
        }
    }
}
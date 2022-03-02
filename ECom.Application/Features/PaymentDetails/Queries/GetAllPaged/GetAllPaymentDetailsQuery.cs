using ECom.Application.Extensions;
using ECom.Application.Interfaces.Repositories;
using ECom.Domain.Entities;
using Paginated.Results;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Queries.GetAllPaged
{
    public class GetAllPaymentDetailsQuery : IRequest<PaginatedResult<GetAllPaymentDetailsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPaymentDetailsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GGetAllPaymentDetailsQueryHandler : IRequestHandler<GetAllPaymentDetailsQuery, PaginatedResult<GetAllPaymentDetailsResponse>>
    {
        private readonly IPaymentDetailRepository _repository;

        public GGetAllPaymentDetailsQueryHandler(IPaymentDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllPaymentDetailsResponse>> Handle(GetAllPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<PaymentDetail, GetAllPaymentDetailsResponse>> expression = e => new GetAllPaymentDetailsResponse
            {
                Id = e.Id,
                CardNumber = e.CardNumber,
                ExpirationDate = e.ExpirationDate,
                CardOwnerName = e.CardOwnerName,
                SecurityCode = e.SecurityCode
            };
            var paginatedList = await _repository.PaymentDetails
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
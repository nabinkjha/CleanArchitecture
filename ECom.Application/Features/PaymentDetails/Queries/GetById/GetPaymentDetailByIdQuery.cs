using ECom.Application.Interfaces.CacheRepositories;
using Paginated.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Queries.GetById
{
    public class GetPaymentDetailByIdQuery : IRequest<Result<GetPaymentDetailByIdResponse>>
    {
        public int Id { get; set; }

        public class GetPaymentDetailByIdQueryHandler : IRequestHandler<GetPaymentDetailByIdQuery, Result<GetPaymentDetailByIdResponse>>
        {
            private readonly IPaymentDetailCacheRepository _PaymentDetailCache;
            private readonly IMapper _mapper;

            public GetPaymentDetailByIdQueryHandler(IPaymentDetailCacheRepository PaymentDetailCache, IMapper mapper)
            {
                _PaymentDetailCache = PaymentDetailCache;
                _mapper = mapper;
            }

            public async Task<Result<GetPaymentDetailByIdResponse>> Handle(GetPaymentDetailByIdQuery query, CancellationToken cancellationToken)
            {
                var PaymentDetail = await _PaymentDetailCache.GetByIdAsync(query.Id);
                var mappedPaymentDetail = _mapper.Map<GetPaymentDetailByIdResponse>(PaymentDetail);
                return Result<GetPaymentDetailByIdResponse>.Success(mappedPaymentDetail);
            }
        }
    }
}
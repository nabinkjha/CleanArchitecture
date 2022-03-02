using ECom.Application.Interfaces.CacheRepositories;
using Paginated.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Queries.GetAllCached
{
    public class GetAllPaymentDetailsCachedQuery : IRequest<Result<List<GetAllPaymentDetailsCachedResponse>>>
    {
        public GetAllPaymentDetailsCachedQuery()
        {
        }
    }

    public class GetAllPaymentDetailsCachedQueryHandler : IRequestHandler<GetAllPaymentDetailsCachedQuery, Result<List<GetAllPaymentDetailsCachedResponse>>>
    {
        private readonly IPaymentDetailCacheRepository _productCache;
        private readonly IMapper _mapper;

        public GetAllPaymentDetailsCachedQueryHandler(IPaymentDetailCacheRepository productCache, IMapper mapper)
        {
            _productCache = productCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPaymentDetailsCachedResponse>>> Handle(GetAllPaymentDetailsCachedQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productCache.GetCachedListAsync();
            var mappedProducts = _mapper.Map<List<GetAllPaymentDetailsCachedResponse>>(productList);
            return Result<List<GetAllPaymentDetailsCachedResponse>>.Success(mappedProducts);
        }
    }
}
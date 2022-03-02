using ECom.Application.Interfaces.CacheRepositories;
using ECom.Application.Interfaces.Repositories;
using ECom.Domain.Entities;
using ECom.Infrastructure.CacheKeys;
using Extensions.Caching;
using ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECom.Infrastructure.CacheRepositories
{
    public class PaymentDetailCacheRepository : IPaymentDetailCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IPaymentDetailRepository _PaymentDetailRepository;

        public PaymentDetailCacheRepository(IDistributedCache distributedCache, IPaymentDetailRepository PaymentDetailRepository)
        {
            _distributedCache = distributedCache;
            _PaymentDetailRepository = PaymentDetailRepository;
        }

        public async Task<PaymentDetail> GetByIdAsync(int PaymentDetailId)
        {
            string cacheKey = PaymentDetailCacheKeys.GetKey(PaymentDetailId);
            var PaymentDetail = await _distributedCache.GetAsync<PaymentDetail>(cacheKey);
            if (PaymentDetail == null)
            {
                PaymentDetail = await _PaymentDetailRepository.GetByIdAsync(PaymentDetailId);
                Throw.Exception.IfNull(PaymentDetail, "PaymentDetail", "No PaymentDetail Found");
                await _distributedCache.SetAsync(cacheKey, PaymentDetail);
            }
            return PaymentDetail;
        }

        public async Task<List<PaymentDetail>> GetCachedListAsync()
        {
            string cacheKey = PaymentDetailCacheKeys.ListKey;
            var PaymentDetailList = await _distributedCache.GetAsync<List<PaymentDetail>>(cacheKey);
            if (PaymentDetailList == null)
            {
                PaymentDetailList = await _PaymentDetailRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, PaymentDetailList);
            }
            return PaymentDetailList;
        }
    }
}
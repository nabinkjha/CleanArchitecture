using ECom.Application.Interfaces.Repositories;
using ECom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Repositories
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly IRepositoryAsync<PaymentDetail> _repository;
        private readonly IDistributedCache _distributedCache;

        public PaymentDetailRepository(IDistributedCache distributedCache, IRepositoryAsync<PaymentDetail> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<PaymentDetail> PaymentDetails => _repository.Entities;

        public async Task DeleteAsync(PaymentDetail PaymentDetail)
        {
            await _repository.DeleteAsync(PaymentDetail);
            await _distributedCache.RemoveAsync(CacheKeys.PaymentDetailCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.PaymentDetailCacheKeys.GetKey(PaymentDetail.Id));
        }

        public async Task<PaymentDetail> GetByIdAsync(int PaymentDetailId)
        {
            return await _repository.Entities.Where(p => p.Id == PaymentDetailId).FirstOrDefaultAsync();
        }

        public async Task<List<PaymentDetail>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(PaymentDetail PaymentDetail)
        {
            await _repository.AddAsync(PaymentDetail);
            await _distributedCache.RemoveAsync(CacheKeys.PaymentDetailCacheKeys.ListKey);
            return PaymentDetail.Id;
        }

        public async Task UpdateAsync(PaymentDetail PaymentDetail)
        {
            await _repository.UpdateAsync(PaymentDetail);
            await _distributedCache.RemoveAsync(CacheKeys.PaymentDetailCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.PaymentDetailCacheKeys.GetKey(PaymentDetail.Id));
        }
    }
}
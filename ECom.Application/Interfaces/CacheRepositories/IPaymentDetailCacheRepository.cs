using ECom.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECom.Application.Interfaces.CacheRepositories
{
    public interface IPaymentDetailCacheRepository
    {
        Task<List<PaymentDetail>> GetCachedListAsync();

        Task<PaymentDetail> GetByIdAsync(int paymentDetailId);
    }
}
using ECom.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Application.Interfaces.Repositories
{
    public interface IPaymentDetailRepository
    {
        IQueryable<PaymentDetail> PaymentDetails { get; }

        Task<List<PaymentDetail>> GetListAsync();

        Task<PaymentDetail> GetByIdAsync(int productId);

        Task<int> InsertAsync(PaymentDetail paymentDetail);

        Task UpdateAsync(PaymentDetail paymentDetail);

        Task DeleteAsync(PaymentDetail paymentDetail);
    }
}
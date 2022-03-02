using ECom.Application.Interfaces.Repositories;
using Paginated.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Commands.Update
{
    public class UpdatePaymentDetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdatePaymentDetailCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPaymentDetailRepository _paymentDetailRepository;

            public UpdateProductCommandHandler(IPaymentDetailRepository paymentDetailRepository, IUnitOfWork unitOfWork)
            {
                _paymentDetailRepository = paymentDetailRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdatePaymentDetailCommand command, CancellationToken cancellationToken)
            {
                var paymentDetail = await _paymentDetailRepository.GetByIdAsync(command.Id);

                if (paymentDetail == null)
                {
                    return Result<int>.Fail($"PaymentDetail Not Found.");
                }
                else
                {
                    paymentDetail.CardOwnerName = command.CardOwnerName ?? paymentDetail.CardOwnerName;
                    paymentDetail.CardNumber = command.CardNumber ?? paymentDetail.CardNumber;
                    paymentDetail.ExpirationDate = command.ExpirationDate ?? paymentDetail.ExpirationDate;
                    paymentDetail.SecurityCode = command.SecurityCode ?? paymentDetail.SecurityCode;
                    await _paymentDetailRepository.UpdateAsync(paymentDetail);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(paymentDetail.Id);
                }
            }
        }
    }
}
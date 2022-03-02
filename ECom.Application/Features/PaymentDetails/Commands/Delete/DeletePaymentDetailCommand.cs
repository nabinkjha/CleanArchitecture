using ECom.Application.Interfaces.Repositories;
using Paginated.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Commands.Delete
{
    public class DeletePaymentDetailCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeletePaymentDetailCommand, Result<int>>
        {
            private readonly IPaymentDetailRepository _paymentDetailRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteProductCommandHandler(IPaymentDetailRepository paymentDetailRepository, IUnitOfWork unitOfWork)
            {
                _paymentDetailRepository = paymentDetailRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePaymentDetailCommand command, CancellationToken cancellationToken)
            {
                var paymentDetail = await _paymentDetailRepository.GetByIdAsync(command.Id);
                await _paymentDetailRepository.DeleteAsync(paymentDetail);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(paymentDetail.Id);
            }
        }
    }
}
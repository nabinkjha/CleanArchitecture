using ECom.Application.Interfaces.Repositories;
using ECom.Domain.Entities;
using Paginated.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECom.Application.Features.PaymentDetails.Commands.Create
{
    public partial class CreatePaymentDetailCommand : IRequest<Result<int>>
    {
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }

    public class CreatePaymentDetailCommandHandler : IRequestHandler<CreatePaymentDetailCommand, Result<int>>
    {
        private readonly IPaymentDetailRepository _paymentDetailRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePaymentDetailCommandHandler(IPaymentDetailRepository paymentDetailRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _paymentDetailRepository = paymentDetailRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<PaymentDetail>(request);
            await _paymentDetailRepository.InsertAsync(product);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(product.Id);
        }
    }
}
namespace ECom.Application.Features.PaymentDetails.Queries.GetById
{
    public class GetPaymentDetailByIdResponse
    {
        public int Id { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
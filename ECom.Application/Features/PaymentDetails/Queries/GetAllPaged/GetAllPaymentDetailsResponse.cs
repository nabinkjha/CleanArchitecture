namespace ECom.Application.Features.PaymentDetails.Queries.GetAllPaged
{
    public class GetAllPaymentDetailsResponse
    {
        public int Id { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
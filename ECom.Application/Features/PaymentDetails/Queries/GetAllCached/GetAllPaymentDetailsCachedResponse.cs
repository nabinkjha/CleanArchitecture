namespace ECom.Application.Features.PaymentDetails.Queries.GetAllCached
{
    public class GetAllPaymentDetailsCachedResponse
    {
        public int Id { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
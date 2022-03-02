using ECom.Core.Domain;

namespace ECom.Domain.Entities
{
    public class PaymentDetail : AuditableEntity
    {
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}

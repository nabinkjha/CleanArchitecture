namespace ECom.Infrastructure.CacheKeys
{
    public static class PaymentDetailCacheKeys
    {
        public static string ListKey => "PaymentDetailList";

        public static string SelectListKey => "PaymentDetailSelectList";

        public static string GetKey(int PaymentDetailId) => $"PaymentDetail-{PaymentDetailId}";

        public static string GetDetailsKey(int PaymentDetailId) => $"PaymentDetailDetails-{PaymentDetailId}";
    }
}
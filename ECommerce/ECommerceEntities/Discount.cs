namespace ECommerceEntities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string? Title { get; set; }
        public decimal? Amount { get; set; }
        public string? CouponCode { get; set; }
        public bool Status { get; set; }
    }
}

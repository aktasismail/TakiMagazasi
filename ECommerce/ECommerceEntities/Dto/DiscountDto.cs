namespace ECommerceEntities.Dto
{
    public record DiscountDto
    {
        public int DiscountId { get; init; }
        public string? Title { get; init; }
        public string? Amount { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public bool Status { get; init; }
    }
}

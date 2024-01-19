namespace ECommerceEntities.Dto.CreateDto
{
    public record DiscountCreateDto
    {
        public string? Title { get; init; }
        public string? Amount { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public bool Status { get; init; }
    }
}

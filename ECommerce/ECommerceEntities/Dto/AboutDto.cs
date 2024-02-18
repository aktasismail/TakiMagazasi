namespace ECommerceEntities.Dto
{
    public record AboutDto
    {
        public int AboutId { get; init; }
        public string? ImageUrl { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
    }
}

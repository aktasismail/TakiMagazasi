namespace ECommerceEntities.Dto.CreateDto
{
    public record AboutCreateDto
    {
        public string? ImageUrl { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
    }
}

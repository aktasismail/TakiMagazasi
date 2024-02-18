namespace ECommerceEntities.Dto.CreateDto
{
    public record ContactCreateDto
    {
        public string? Location { get; init; }
        public string? Phone { get; init; }
        public string? Mail { get; init; }
        public string? Title { get; init; }
        public string Description { get; init; }
    }
}

namespace ECommerceEntities.Dto
{
    public record ContactDto
    {
        public int ContactId { get; init; }
        public string? Location { get; init; }
        public string? Phone { get; init; }
        public string? Mail { get; init; }
        public string? Title { get; init; }
        public string Description { get; init; }
    }
}

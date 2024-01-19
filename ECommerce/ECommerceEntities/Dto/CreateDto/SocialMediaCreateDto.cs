namespace ECommerceEntities.Dto.CreateDto
{
    public record SocialMediaCreateDto
    {
        public string? Title { get; init; }
        public string? Url { get; init; }
        public string? Icon { get; init; }
    }
}

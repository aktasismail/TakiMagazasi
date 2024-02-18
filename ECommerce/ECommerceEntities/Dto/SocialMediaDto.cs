namespace ECommerceEntities.Dto
{
    public record SocialMediaDto
    {
        public int SocialMediaId { get; init; }
        public string? Title { get; init; }
        public string? Url { get; init; }
        public string? Icon { get; init; }
    }
}

namespace ECommerceEntities.Dto
{
    public record CategoryDto
    {
        public int CategoryId { get; init; }
        public string? CategoryName { get; init; }
    }
}

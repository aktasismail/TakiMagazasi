
namespace ECommerceEntities.Dto.CreateDto
{
    public record CommentCreateDto
    {
        public string? Text { get; set; }
        public string? FullName { get; set; }
        public int ProductId { get; set; }
        public string Uid { get; set; }
    }
}

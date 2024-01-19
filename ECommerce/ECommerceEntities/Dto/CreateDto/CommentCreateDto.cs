
namespace ECommerceEntities.Dto.CreateDto
{
    public record CommentCreateDto
    {
        public string? FullName { get; set; }
        public string? Text { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}

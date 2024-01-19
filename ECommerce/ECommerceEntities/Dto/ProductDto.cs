using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string? ProductName { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public string? ImageUrl { get; init; }
        public bool IsActice { get; set; }
        public int CategoryId { get; init; }

    }
}

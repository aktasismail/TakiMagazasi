using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto.CreateDto
{
    public record ProductCreateDto
    {
        public string? ProductName { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public string? ImageUrl { get; set; }
        public bool IsActice { get; set; }
        public int CategoryId { get; init; }

    }
}

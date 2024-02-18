using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto.CreateDto
{
    public record OrderCreateDto
    {
        public string? TableNumber { get; init; }
        public string? Description { get; init; }

        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; init; }
        public decimal TotalPrice { get; init; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto.CreateDto
{ 
    public record CartCreateDto
    {
        public decimal Price { get; init; }
        public decimal Count { get; init; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}

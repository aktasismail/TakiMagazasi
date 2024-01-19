using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto
{
    public record CartDto
    {
        public int CartId { get; init; }
        public decimal Price { get; init; }
        public decimal Count { get; init; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}

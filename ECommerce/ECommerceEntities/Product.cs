using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActice { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Cart> Cart { get; set; }
    }
}

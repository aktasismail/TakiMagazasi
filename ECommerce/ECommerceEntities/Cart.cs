using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities
{
    public class Cart
    {
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; } = null!;
    }
}

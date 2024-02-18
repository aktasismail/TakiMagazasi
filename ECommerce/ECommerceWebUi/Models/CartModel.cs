namespace ECommerceWebUi.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
    }
}

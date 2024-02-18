using System.ComponentModel.DataAnnotations;

namespace ECommerceEntities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public bool IsShipped { get; set; } = false;
        public string? Status { get; set; } = "Siparişiniz Alındı";
        public string? Tracking { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}

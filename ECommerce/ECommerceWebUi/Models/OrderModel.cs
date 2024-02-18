using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUi.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public DateTime OrderDate { get; set; }
        [Required]

        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Apartment { get; set; }

        public List<CartModel> Items { get; set; } = new List<CartModel>();
    }
}

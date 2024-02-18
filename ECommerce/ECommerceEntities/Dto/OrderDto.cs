using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceEntities.Dto
{
    public record OrderDto
    {
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
    }
}

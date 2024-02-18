using ECommerceEntities;

namespace ECommerceWebUi.Models
{
    public class OrderDetailVM
    {
        public Order Order { get; set; }
        public List<Order> ListOrder { get; set; }
        public AppUser AppUser { get; set; }
    }
}

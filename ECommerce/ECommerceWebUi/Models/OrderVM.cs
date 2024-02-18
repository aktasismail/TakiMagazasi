using ECommerceEntities.Dto;
using ECommerceEntities;

namespace ECommerceWebUi.Models
{
    public class OrderVM
    {
        public OrderDto _orderDto { get; set; } = new OrderDto();
        public List<Product> _product { get; set; } = new List<Product>();
    }
}

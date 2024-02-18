using ECommerceEntities;
using ECommerceEntities.Dto;

namespace ECommerceBusiness.Abstract
{
    public interface IOrderService
    {
        Task<ServiceResponse<Order>> CreateOrder(OrderDto model, List<Product> _product);
        Task<ServiceResponse<List<Order>>> ListOrders();
        Task<Order> GetOrderById(int id);
        Task<List<Order>> MyOrders(string userId);
    }
}

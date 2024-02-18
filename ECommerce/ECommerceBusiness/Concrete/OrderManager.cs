using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBusiness.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public OrderManager(AppDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<Order>> CreateOrder(OrderDto model, List<Product> _product)
        {
            ServiceResponse<Order> _serviceResponse = new ServiceResponse<Order>();
            var objDTO = _mapper.Map<Order>(model);
            objDTO.OrderDate = DateTime.UtcNow;
            _context.Orders.Add(objDTO);
            await _context.SaveChangesAsync();
            var insertedOrder = _context.Orders.Single(x => x.OrderId == objDTO.OrderId);
            insertedOrder.Products = new List<Product>();
            if (insertedOrder != null)
            {
                foreach (var item in _product)
                {
                    item.Category = null;
                    insertedOrder.Products.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            _serviceResponse.Message = "Opersyon ";
            _serviceResponse.Success = true;
            _serviceResponse.Data = objDTO;
            return _serviceResponse;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.Where(x => x.OrderId == id).SingleOrDefaultAsync();
            return order;
        }
        public Task<ServiceResponse<List<Order>>> ListOrders()
        {
            throw new NotImplementedException();
        }

        public  Task<List<Order>> MyOrders(string userId)
        {
            var order =  _context.Orders.Include(x => x.Products).Where(x=> x.UserId == userId).ToListAsync();
            return order;

        }
    }
}

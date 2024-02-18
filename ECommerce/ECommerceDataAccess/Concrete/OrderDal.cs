//using ECommerceDataAccess.Abstract;
//using ECommerceDataAccess.Data;
//using ECommerceEntities;

//namespace ECommerceDataAccess.Concrete
//{
//    public class OrderDal : Repository<Order>, IOrderDal
//    {
//        public OrderDal(AppDbContext context) : base(context)
//        {
//        }

//        public int ActiveOrderCount()
//        {
//            using var context = new AppDbContext();
//            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
//        }

//        public decimal LastOrderPrice()
//        {
//            using var context = new AppDbContext();
//            return context.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
//        }

//        public decimal TodayTotalPrice()
//        {
//            return 0;
//        }

//        public int TotalOrderCount()
//        {
//            using var context = new AppDbContext();
//            return context.Orders.Count();
//        }
//    }
//}

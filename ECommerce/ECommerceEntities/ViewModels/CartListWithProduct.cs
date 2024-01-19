using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.ViewModels
{
    public class CartListWithProduct
    {
        public int CartId{ get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}

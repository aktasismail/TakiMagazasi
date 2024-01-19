using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.ViewModels
{
    public class FavoriteListModel
    {
        public int FavouriteId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.Dto
{
    public class FavouriteDto
    {
        public int favouriteId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}

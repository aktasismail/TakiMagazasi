using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.Dto.CreateDto
{
    public class FavouriteCreateDto
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}

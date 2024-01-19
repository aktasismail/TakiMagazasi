using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.ViewModels
{
    public class CommentModels 
    {
        public ProductDto productDto { get; set; }
        public CommentCreateDto commentCreateDto { get; set; }

    }
}

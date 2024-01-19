using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.Dto
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string? FullName { get; set; }
        public string? Text { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }
        public string? FullName { get; set; }
        public string? Text { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; } = null!;
    }
}

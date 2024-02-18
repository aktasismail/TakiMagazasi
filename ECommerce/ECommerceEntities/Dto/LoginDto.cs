using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.Dto
{
    public record LoginDto
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Lüten şifreyi giriniz")]
        public string Password { get; init; }
        public bool RememberMe { get; init; }
    }
}

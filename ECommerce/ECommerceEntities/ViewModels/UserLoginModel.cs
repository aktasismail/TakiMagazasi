using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.ViewModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "E posta gereklidir")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password gereklidir")]
        public string Password { get; set; } = null!;
		public bool RememberMe { get; set; }
	}
}

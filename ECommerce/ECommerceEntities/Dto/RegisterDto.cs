using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities.Dto
{
    public record RegisterDto
    {
        public string? Name { get; init; }
        public string? Surname { get; init; }
        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        public string? UserName { get; init; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Şifreyi giriniz")]
        public string? Password { get; init; }
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor.")]
		public string ConfirmPassword { get; set; } = string.Empty;
		public string? Email { get; init; }
    }
}

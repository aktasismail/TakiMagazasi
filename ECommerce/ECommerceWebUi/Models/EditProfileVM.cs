using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUi.Models
{
    public class EditProfileVM
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil")]
        public string? ConfirmPassword { get; set; }
    }
}

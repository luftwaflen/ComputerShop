using System.ComponentModel.DataAnnotations;

namespace ComputerShopIdentityWebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не введено имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не введен email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}

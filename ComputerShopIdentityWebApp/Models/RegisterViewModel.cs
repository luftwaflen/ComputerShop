using System.ComponentModel.DataAnnotations;

namespace ComputerShopIdentityWebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не введено имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не введен email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не введен пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}

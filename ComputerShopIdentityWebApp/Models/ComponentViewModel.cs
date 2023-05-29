using System.ComponentModel.DataAnnotations;

namespace ComputerShopIdentityWebApp.Models
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не введено название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не введено описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не введена цена")]
        public decimal Coast { get; set; }
        [Required(ErrorMessage = "Не введена ссылка")]
        public string ImageUrl { get; set; }
    }
}

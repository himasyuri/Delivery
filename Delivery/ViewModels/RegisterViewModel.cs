using System.ComponentModel.DataAnnotations;

namespace Delivery.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Ваша компания")]
        public string Company { get; set; }
        [Required]
        [Display(Name ="Телефон")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}

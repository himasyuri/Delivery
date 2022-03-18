using System.ComponentModel.DataAnnotations;

namespace Delivery.ViewModels
{
    public class ApplicationViewModel
    {
        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Колличество машин")]
        public int NumberOfCars { get; set; }
        [Required]
        [Display(Name = "Откуда")]
        public string StartedWay { get; set; }
        [Required]
        [Display(Name = "Куда")]
        public string EndedWay { get; set; }
    }
}

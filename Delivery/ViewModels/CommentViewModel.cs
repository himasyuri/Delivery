using System.ComponentModel.DataAnnotations;

namespace Delivery.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        [Display(Name ="Текст комментария")]
        public string Description { get; set; }
    }
}

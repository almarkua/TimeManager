using System;
using System.ComponentModel.DataAnnotations;

namespace TimeManager.Models
{
    public class NewCase
    {
        [Required(ErrorMessage = "Не заповнено поле \"Короткий опис\"")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Мінімальна довжина короткого опису справи 20 символів!")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Не заповнено поле \"Детальний опис\"")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "Мінімальна довжина опису справи 50 символів!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не обрано початкову дату")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Не обрано кінцеву дату.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Не обрано категорію!")]
        public string CategoryName { get; set; }
        [Range(1,5,ErrorMessage = "Не обрано пріоритет!")]
        public int Priority { get; set; }

        public NewCase()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }
}
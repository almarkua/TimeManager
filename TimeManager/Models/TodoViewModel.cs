using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeManager.Models
{
    public class AddTodoAjaxViewModel
    {
        [Required(ErrorMessage = "Не заповнено поле \"Короткий опис\"")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Мінімальна довжина короткого опису справи 10 символів!")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Не заповнено поле \"Детальний опис\"")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Мінімальна довжина опису справи 20 символів!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не обрано початкову дату")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Справа уже виконана")]
        public bool IsDone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Не обрано категорію!")]
        public string CategoryName { get; set; }
        [Range(1, 5, ErrorMessage = "Не обрано пріоритет!")]
        [Required(ErrorMessage = "Не обрано пріоритет!")]
        public int Priority { get; set; }

        public AddTodoAjaxViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }

    public class AddOrEditTodoViewModel
    {
        [HiddenInput]
        public int TodoId { get; set; }
        [Required(ErrorMessage = "Не заповнено поле \"Короткий опис\"")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Мінімальна довжина короткого опису справи 10 символів!")]
        [DisplayName("Короткий опис")]
        public string ShortDescription { get; set; }

        [DisplayName("Детальний опис")]
        [Required(ErrorMessage = "Не заповнено поле \"Детальний опис\"")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Мінімальна довжина опису справи 20 символів!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не обрано початкову дату")]
        [DisplayName("Початкова дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Справа уже виконана")]
        public bool IsDone { get; set; }
        
        [DisplayName("Кінцева дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }

        [DisplayName("Категорія")]
        [Required(ErrorMessage = "Не обрано категорію!")]
        public string CategoryId { get; set; }

        [DisplayName("Пріоритет")]
        [Range(1, 5, ErrorMessage = "Не обрано пріоритет!")]
        [Required(ErrorMessage = "Не обрано пріоритет!")]
        public string Priotiry  { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }

        public AddOrEditTodoViewModel()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }
}
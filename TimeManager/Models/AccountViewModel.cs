using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.Owin.Security;

namespace TimeManager.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректний e-mail")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [MinLength(2, ErrorMessage = "Мініальна довжина імені 2 симовла")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина імені 20 симовла")]
        [DisplayName("Ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [MinLength(2, ErrorMessage = "Мініальна довжина прізвища 2 симовла")]
        [MaxLength(20, ErrorMessage = "Максимальна довжина прізвища 20 симовла")]
        [DisplayName("Прізвище")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некоректний e-mail")]
        [DisplayName("Електронна адреса")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповнене!")]
        [DisplayName("Підтвердження пароля")]
        public string RePassword { get; set; }
    }

}
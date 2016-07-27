using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CgemoHivTests.WebUI.Models
{
    public class ChangePasswordModel
    {
        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Заполните поле старый пароль")]
        [DisplayName("Старый пароль")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Заполните поле пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле повторить пароль")]
        [DisplayName("Повторить пароль")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
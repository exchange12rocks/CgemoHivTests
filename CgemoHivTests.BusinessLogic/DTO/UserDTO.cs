using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace CgemoHivTests.BusinessLogic.DTO
{
    public class UserDTO
    {
        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public System.Guid UserId { get; set; }

        [Required(ErrorMessage = "Заполните поле логин")]
        [DisplayName("Имя пользователя")]
        //[System.Web.Mvc.Remote("CheckUserName", "Account")]
        public string UserName { get; set; }
        [DisplayName("Имя пользователя")]
        public string LoweredUserName { get; set; }
        
        [Required(ErrorMessage = "Заполните поле пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле повторить пароль")]
        [DisplayName("Повторить пароль")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Отключен")]
        public bool IsApproved { get; set; }

        [DisplayName("Заблокирован")]
        public bool IsLockedOut { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [DisplayName("Email")]
        public string LoweredEmail { get; set; }

        [DisplayName("Дата создания")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)] 
        public System.DateTime CreateDate { get; set; }

        [DisplayName("Дата последнего входа в систему")]
        [DataType(DataType.DateTime)]
        public System.DateTime LastLoginDate { get; set; }

        public int FailedPasswordAttemptCount { get; set; }
    }
}
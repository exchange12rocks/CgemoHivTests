using CgemoHivTests.BusinessLogic.Providers;
using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.BusinessLogic.Infrastructure;
using CgemoHivTests.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using System.Transactions;

namespace CgemoHivTests.WebUI.Controllers
{
    public class AccountController : Controller
    {      
        public AccountController()
        {
            ViewBag.SelectedPage = "Users";
        }
        [Authorize()]
        public ActionResult Users()
        {
            return View();
            //return View(((CgemoMembershipProvider)Membership.Provider).GetAllUsers());
        }
        public PartialViewResult GetUsers()
        {
            return PartialView("_UserList", ((CgemoMembershipProvider)Membership.Provider).GetAllUsers());
        }       
        public ActionResult Edit(string userName)
        {
            UserDTO user;
            if (userName == null) 
            { 
                ViewBag.DialogTitle = "Новый"; 
                user = new UserDTO(); 
            }
            else
            {
                ViewBag.DialogTitle = userName;
                user = ((CgemoMembershipProvider)Membership.Provider).GetUser(userName);
            }
            return PartialView("_UserForm", user);
        }
        public bool CheckUserName(string UserName)
        {
            return (((CgemoMembershipProvider)Membership.Provider).GetUser(UserName) == null) ? true : false;
        }
        public ActionResult Delete(string userName)
        {
            MessageBox ResultStatus = new MessageBox();
            if (Membership.Provider.DeleteUser(userName, true))
            {
                ResultStatus.ResultId = Result.Success; 
                ResultStatus.Message = String.Format("Пользователь {0} удален", userName);
            }
            else
            {
                ResultStatus.ResultId = Result.Error;
                ResultStatus.Message = "Не удалось удалить пользователя";
            }
            TempData["result"] = JsonConvert.SerializeObject(ResultStatus);
            return PartialView("_UserList", ((CgemoMembershipProvider)Membership.Provider).GetAllUsers());
        }
        public ActionResult Save(UserDTO user)
        {
            MessageBox ResultStatus = new MessageBox();
            bool IsValid = false;

            if (user.UserId == Guid.Empty)
            {
                if (ModelState.IsValidField("UserName")
                    && ModelState.IsValidField("Password")
                    && ModelState.IsValidField("ConfirmPassword"))
                {
                    MembershipCreateStatus MembershipStatus;
                    UserDTO newUser = ((CgemoMembershipProvider)Membership.Provider).
                        CreateUser(user.UserName, user.Password, user.Email, user.IsApproved, out MembershipStatus);
                    if (newUser == null) ResultStatus.ResultId = Result.Error;
                    else ResultStatus.ResultId = Result.Success;
                    ResultStatus.Message = GetMembershipStatus(MembershipStatus);
                    IsValid = true;
                }
            }
            else
            {
                if (ModelState.IsValidField("UserName"))
                {
                    IsValid = true;
                    try
                    {
                        ((CgemoMembershipProvider)Membership.Provider).UpdateUser(user);
                        ResultStatus.ResultId = Result.Success;
                        ResultStatus.Message += String.Format(" Данные пользователя {0} успешно изменены.", user.UserName);                      
                    }
                    catch (Exception ex)
                    {
                        ResultStatus.ResultId = Result.Error;
                        ResultStatus.Message = String.Format("Ошибка. {0}", ex.Message);
                    }
                }
            }
            if(!IsValid)
            {
                HttpContext.Response.AddHeader("IsValid", "False");
                return PartialView("_UserForm", user);
            }

            HttpContext.Response.AddHeader("IsValid", "True");
            TempData["result"] = JsonConvert.SerializeObject(ResultStatus);
            return PartialView("_UserList", ((CgemoMembershipProvider)Membership.Provider).GetAllUsers());
        }
        public ActionResult ChangePassword(string userName)
        {
            ChangePasswordModel model = new ChangePasswordModel();
            model.UserName = userName;
            return PartialView("_ChangePasswordForm", model);
        }
        public ActionResult SavePassword(ChangePasswordModel model)
        {
            MessageBox ResultStatus = new MessageBox();
            if(ModelState.IsValid)
            {
                try
                {
                    bool result = ((CgemoMembershipProvider)Membership.Provider).
                        ChangePassword(model.UserName, model.OldPassword, model.Password);
                    if (!result) throw new Exception("Не удалось изменить пароль.");
                    ResultStatus.ResultId = Result.Success;
                    ResultStatus.Message = "Пароль для пользователь  успешно изменен.";
                }
                catch(Exception ex)
                {
                    ResultStatus.ResultId = Result.Error;
                    ResultStatus.Message = String.Format("{0} Возможно вы неверно ввели старый пароль", ex.Message);
                }
            }
            else
            {
                HttpContext.Response.AddHeader("IsValid", "False");
                return PartialView("_ChangePasswordForm", model);
            }
            HttpContext.Response.AddHeader("IsValid", "True");
            TempData["result"] = JsonConvert.SerializeObject(ResultStatus);
            return Edit(model.UserName);
        }
        private string GetMembershipStatus(MembershipCreateStatus MembershipStatus)
        {
            switch (MembershipStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    {
                        return "Пользователь с таким именем уже существует";
                    }
                case MembershipCreateStatus.InvalidUserName:
                    {
                        return "Некорректный логин";
                    }
                case MembershipCreateStatus.InvalidPassword:
                    {
                        return "Некорректный пароль";
                    }
                case MembershipCreateStatus.ProviderError:
                    {
                        return "Не удалось создать нового пользователя";
                    }
                case MembershipCreateStatus.Success:
                    {
                        return "Пользователь успешно создан";
                    }
                default:
                    {
                        return "Что то совсем непонятное!";
                    }
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}
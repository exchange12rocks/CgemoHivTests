using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.Services;
using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.DataAccess.Repositories;
using System.Collections.Specialized;
using Ninject;

namespace CgemoHivTests.BusinessLogic.Providers
{
    public class CgemoMembershipProvider : MembershipProvider
    {
        [Inject]
        public IUserService<UserDTO> userService { get; set; }      
        public CgemoMembershipProvider() {}
        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            try
            {
                UserDTO user = userService.Get(username);
                if (user != null
                    && Crypto.VerifyHashedPassword(user.Password, password)
                    && !user.IsApproved
                    && !user.IsLockedOut)
                {
                    isValid = true;
                    user.LastLoginDate = DateTime.Now;
                    userService.Update(user);
                }
            }
            catch { isValid = false; }

            return isValid;
        }
        public UserDTO CreateUser(string userName, string password, string email, bool isApproved, out MembershipCreateStatus status)
        {
            UserDTO membershipUser = userService.Get(userName);
            if (membershipUser == null)
            {
                try
                {
                    UserDTO user = new UserDTO();
                    user.UserId = Guid.NewGuid();
                    user.LoweredUserName = 
                        (user.UserName = userName).ToLower();
                    if(!String.IsNullOrEmpty(email)) 
                        user.LoweredEmail = 
                            (user.Email = email).ToLower();
                    user.Password = Crypto.HashPassword(password);
                    user.IsApproved = isApproved;
                    user.IsLockedOut = false;
                    user.CreateDate = DateTime.Now;
                    user.LastLoginDate = DateTime.Now;
                    userService.Create(user);
                    status = MembershipCreateStatus.Success;
                    return user;
                }
                catch
                {
                    status = MembershipCreateStatus.ProviderError;
                    return null;
                }
            }
            status = MembershipCreateStatus.DuplicateUserName;
            return null;
        }
        public UserDTO GetUser(string userName)
        {
            try
            {
                UserDTO user = userService.Get(userName);
                user.Password = null;
                return user;
            }
            catch { return null; }
        }
        public IEnumerable<UserDTO> GetAllUsers()
        {
            try
            {
                return userService.GetAll();
            }
            catch { return null; }
        }
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            UserDTO membershipUser = userService.Get(username);
            if (membershipUser != null)
            {
                try
                {
                    userService.Delete(membershipUser);
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            UserDTO user = userService.Get(username);
            if (user != null)
            {
                if (Crypto.VerifyHashedPassword(user.Password, oldPassword))
                {
                    try
                    {
                        user.Password = Crypto.HashPassword(newPassword);
                        userService.Update(user);
                        return true;
                    }
                    catch { return false; }
                }
            }
            return false;
        }
        public void UpdateUser(UserDTO user)
        {
            try
            {
                UserDTO updUser = userService.Get(user.UserName);
                if (!String.IsNullOrEmpty(user.Email))
                    updUser.LoweredEmail = (updUser.Email = user.Email).ToLower();
                else updUser.LoweredEmail = updUser.Email = null;
                updUser.IsApproved = user.IsApproved;
                userService.Update(updUser);
            }
            catch { throw new Exception("Не удалось изменить пользователя"); }
        }
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }      
        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser GetUser(string userName, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }      
    }
}

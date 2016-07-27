using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.DataAccess.Interfaces;
using CgemoHivTests.DataAccess;
using System.Linq.Expressions;

namespace CgemoHivTests.BusinessLogic.Services
{
    public class UserService : IUserService<UserDTO>
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public UserDTO Get(string userName)
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<User, UserDTO>(Database.Users.Get(userName));
        }
        public IEnumerable<UserDTO> GetAll()
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<IQueryable<User>, List<UserDTO>>(Database.Users.GetAll());
        }
        public IEnumerable<UserDTO> FindBy(Expression<Func<UserDTO, bool>> predicate)
        {
            Mapper.CreateMap<Expression<Func<UserDTO, bool>>, Expression<Func<User, bool>>>();
            Expression<Func<User, bool>> predicateD = Mapper.Map<Expression<Func<UserDTO, bool>>, Expression<Func<User, bool>>>(predicate);

            Mapper.CreateMap<IQueryable<User>, List<UserDTO>>();
            return Mapper.Map<IQueryable<User>, List<UserDTO>>(Database.Users.FindeBy(predicateD));
        }
        public void Create(UserDTO entity)
        {
            Mapper.CreateMap<UserDTO, User>();
                //.ForMember("UserId", opt => opt.MapFrom(u => u.UserId))
                //.ForMember("UserName", opt => opt.MapFrom(u => u.UserName))
                //.ForMember("LoweredUserName", opt => opt.MapFrom(u => u.LoweredUserName))
                //.ForMember("FullUserName", opt => opt.MapFrom(u => u.FullUserName))
                //.ForMember("Password", opt => opt.MapFrom(u => u.Password))
                //.ForMember("IsApproved", opt => opt.MapFrom(u => u.IsApproved))
                //.ForMember("IsLockedOut", opt => opt.MapFrom(u => u.IsLockedOut)); 
            Database.Users.Add(Mapper.Map<UserDTO, User>(entity));
            Database.Save();
        }
        public void Update(UserDTO entity)
        {
            Mapper.CreateMap<UserDTO, User>();
            Database.Users.Edit(Mapper.Map<UserDTO, User>(entity));
            Database.Save();
        }
        public void Delete(UserDTO entity)
        {
            Mapper.CreateMap<UserDTO, User>();
            Database.Users.Delete(Mapper.Map<UserDTO, User>(entity));
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

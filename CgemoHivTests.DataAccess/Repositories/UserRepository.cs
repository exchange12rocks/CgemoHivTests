using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace CgemoHivTests.DataAccess.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        CgemoHivTestsContext context;
        public UserRepository(CgemoHivTestsContext dbContext)
        {
            context = dbContext;
        }
        public IQueryable<User> GetAll()
        {
            return context.Users.AsQueryable<User>();
        }
        public User Get(string userName)
        {
            return this.FindeBy(u => u.LoweredUserName == userName.ToLower()).SingleOrDefault();
        }
        public IQueryable<User> FindeBy(Expression<Func<User, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
        public void Add(User entity)
        {
            context.Users.Add(entity);
        }
        public void Delete(User entity)
        {
            var removeEntity = context.Users.Find(entity.UserId);
            context.Users.Remove(removeEntity);
        }
        public void Edit(User entity)
        {
            var originalEntity = context.Users.Find(entity.UserId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.DataAccess.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(string userName);
        IQueryable<T> FindeBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}

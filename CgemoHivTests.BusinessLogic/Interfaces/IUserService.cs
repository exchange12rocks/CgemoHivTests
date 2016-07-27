using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.BusinessLogic.DTO;

namespace CgemoHivTests.BusinessLogic.Interfaces
{
    public interface IUserService<T> where T : class
    {
        UserDTO Get(string userName);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Dispose();
    }
}

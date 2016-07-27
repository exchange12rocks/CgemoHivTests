using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.BusinessLogic.Interfaces
{
    public interface IDbService<T> where T : class
    {
        T GetEntity(int? id);
        IEnumerable<T> GetEntities();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void SaveEntity(T entity);
        void SaveEntities(IEnumerable<T> entitiesList);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        void Dispose();
    }
}

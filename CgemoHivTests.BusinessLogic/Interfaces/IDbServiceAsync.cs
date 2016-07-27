using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.BusinessLogic.DTO;
using System.Linq.Expressions;

namespace CgemoHivTests.BusinessLogic.Interfaces
{
    public interface IDbServiceAsync<T> where T : class
    {
        Task<T> GetEntityAsync(int? id);
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task SaveEntityAsync(T entity);
        Task SaveEntitiesAsync(IEnumerable<T> entitiesList);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(T entity);
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;

namespace CgemoHivTests.DataAccess.Repositories
{
    public class UpdateLogRepository : IRepository<UpdateLog>
    {
        CgemoHivTestsContext context;
        public UpdateLogRepository(CgemoHivTestsContext dbContext)
        {
            context = dbContext;
        }
        public IQueryable<UpdateLog> GetAll()
        {
            return context.UpdateLogs.AsQueryable<UpdateLog>();
        }
        public UpdateLog Get(int id)
        {
            //var query = from d in context.Declarants 
            //            where d.Id == declarantId 
            //            select d;
            //return query.SingleOrDefault();
            return context.UpdateLogs.Find(id);
        }
        public IQueryable<UpdateLog> FindeBy(System.Linq.Expressions.Expression<Func<UpdateLog, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
        public void Add(UpdateLog entity)
        {
            context.UpdateLogs.Add(entity);
        }
        public void Delete(UpdateLog entity)
        {
            var removeEntity = context.UpdateLogs.Find(entity.Id);
            context.UpdateLogs.Remove(removeEntity);
        }
        public void Edit(UpdateLog entity)
        {
            var originalEntity = context.UpdateLogs.Find(entity.Id);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }
    }
}

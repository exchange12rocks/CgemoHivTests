using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace CgemoHivTests.DataAccess.Repositories
{
    public class DeclarantRepository : IRepository<Declarant>
    {
        CgemoHivTestsContext context;
        public DeclarantRepository(CgemoHivTestsContext dbContext)
        {
            context = dbContext;
        }
        public IQueryable<Declarant> GetAll()
        {
            return context.Declarants.AsQueryable<Declarant>();
        }
        public Declarant Get(int id)
        {
            //var query = from d in context.Declarants 
            //            where d.Id == declarantId 
            //            select d;
            //return query.SingleOrDefault();
            return context.Declarants.Find(id);
        }
        public IQueryable<Declarant> FindeBy(Expression<Func<Declarant, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
        public void Add(Declarant entity)
        {
            context.Declarants.Add(entity);
        }
        public void Delete(Declarant entity)
        {
            var removeEntity = context.Declarants.Find(entity.Id);
            context.Declarants.Remove(removeEntity);
        }
        public void Edit(Declarant entity)
        {
            var originalEntity = context.Declarants.Find(entity.Id);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }
        //public void Dispose()
        //{
        //    if (context != null)
        //    {
        //        context.Dispose();
        //        context = null;
        //    }
        //    GC.SuppressFinalize(this);
        //}
    }
}

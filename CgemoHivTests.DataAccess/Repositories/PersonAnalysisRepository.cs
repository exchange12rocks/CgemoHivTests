using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace CgemoHivTests.DataAccess.Repositories
{
    public class PersonAnalysisRepository : IRepository<PersonAnalysis>
    {
        CgemoHivTestsContext context;      
        public PersonAnalysisRepository(CgemoHivTestsContext dbContext)
        {
            context = dbContext;
        }
        public IQueryable<PersonAnalysis> GetAll()
        {
            return context.Persons.AsNoTracking().AsQueryable<PersonAnalysis>();
        }
        //public async Task<IQueryable<PersonAnalysis>> GetAllAsync()
        //{
        //    return await Task.Run<IQueryable<PersonAnalysis>>(() =>
        //        {
        //            return context.PersonAnalyses.AsNoTracking().AsQueryable<PersonAnalysis>();
        //        });
        //}
        //public async Task<PersonAnalysis> GetAsync(int personId)
        //{
        //    //return await Task.Run<PersonAnalysis>(() =>
        //    //{
        //    //    System.Threading.Thread.Sleep(5000);
        //    //    return context.PersonAnalyses.AsNoTracking().FirstOrDefault(pa => pa.PersonId == personId);
        //    //});
        //    return await context.PersonAnalyses.AsNoTracking().FirstOrDefaultAsync(pa => pa.PersonId == personId);
        //}
        public PersonAnalysis Get(int personId)
        {
            return context.Persons.AsNoTracking().SingleOrDefault(pa => pa.PersonId == personId);
        }
        public IQueryable<PersonAnalysis> FindeBy(Expression<Func<PersonAnalysis, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
        //public async Task<IQueryable<PersonAnalysis>> FindeByAsync(Expression<Func<PersonAnalysis, bool>> predicate)
        //{
        //    return await Task.Run<IQueryable<PersonAnalysis>>(() =>
        //    {
        //        return context.PersonAnalyses.Where(predicate);
        //    });
        //}
        public void Add(PersonAnalysis entity)
        {
            context.Persons.Add(entity);
        }
        public void Edit(PersonAnalysis entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void Delete(PersonAnalysis entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        
        //public async Task SaveEntityesAsync(IList<PersonAnalysis> entityList)
        //{
        //    await Task.Run(() =>
        //        {
        //            foreach (PersonAnalysis p in entityList) this.Add(p);
        //            this.Save();
        //        });
        //}
    }
}

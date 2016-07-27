using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CgemoHivTests.DataAccess;
using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace CgemoHivTests.BusinessLogic.Services
{
    public class PersonAnalysisService : IDbServiceAsync<PersonAnalysisDTO>
    {
        IUnitOfWork Database { get; set; }
        public PersonAnalysisService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<PersonAnalysisDTO> GetEntityAsync(int? id)
        {
            return await Task.Run<PersonAnalysisDTO>(() =>
            {
                Mapper.CreateMap<PersonAnalysis, PersonAnalysisDTO>();
                return Mapper.Map<PersonAnalysis, PersonAnalysisDTO>(Database.PersonAnalyses.Get(id.Value));
            });
        }
        public async Task<IEnumerable<PersonAnalysisDTO>> GetEntitiesAsync()
        {
            return await Task.Run<IEnumerable<PersonAnalysisDTO>>(() =>
            {
                Mapper.CreateMap<PersonAnalysis, PersonAnalysisDTO>();
                return Mapper.Map<IQueryable<PersonAnalysis>, List<PersonAnalysisDTO>>(Database.PersonAnalyses.GetAll());
            });
        }
        public async Task<IEnumerable<PersonAnalysisDTO>> FindByAsync(Expression<Func<PersonAnalysisDTO, bool>> predicate)
        {
            return await Task.Run<IEnumerable<PersonAnalysisDTO>>(() =>
            {
                Mapper.CreateMap<PersonAnalysis, PersonAnalysisDTO>();
                Expression<Func<PersonAnalysis, bool>> expression = Mapper.Map<Expression<Func<PersonAnalysis, bool>>>(predicate);
                return Mapper.Map<IQueryable<PersonAnalysis>, List<PersonAnalysisDTO>>(Database.PersonAnalyses.FindeBy(expression));
            });

            //return await Task.Run<IEnumerable<PersonAnalysisDTO>>(() =>
            //{
            //    Mapper.CreateMap<PersonAnalysis, PersonAnalysisDTO>();               
            //    Expression<Func<PersonAnalysis, bool>> predicateP = Mapper.Map<Expression<Func<PersonAnalysisDTO, bool>>, Expression<Func<PersonAnalysis, bool>>>(predicate);

            //    Mapper.CreateMap<IQueryable<PersonAnalysis>, List<PersonAnalysisDTO>>();
            //    return Mapper.Map<IQueryable<PersonAnalysis>, List<PersonAnalysisDTO>>(Database.PersonAnalyses.FindeBy(predicateP));
            //});
        }
        public IEnumerable<PersonAnalysisDTO> FindBy(Expression<Func<PersonAnalysisDTO, bool>> predicate)
        {
            Mapper.CreateMap<PersonAnalysis, PersonAnalysisDTO>();
            //Mapper.CreateMap<Expression<Func<PersonAnalysisDTO, bool>>, Expression<Func<PersonAnalysis, bool>>>();
            Expression<Func<PersonAnalysis, bool>> expression = 
                Mapper.Map<Expression<Func<PersonAnalysis, bool>>>(predicate);
            return Mapper.Map<IQueryable<PersonAnalysis>, List<PersonAnalysisDTO>>(Database.PersonAnalyses.FindeBy(expression));
        }
        public async Task SaveEntityAsync(PersonAnalysisDTO entity)
        {
            await Task.Run(() =>
            {
                Mapper.CreateMap<PersonAnalysisDTO, PersonAnalysis>();
                Database.PersonAnalyses.Add(Mapper.Map<PersonAnalysisDTO, PersonAnalysis>(entity));
                Database.Save();
            });
        }
        public async Task SaveEntitiesAsync(IEnumerable<PersonAnalysisDTO> entitiesList)
        {
            await Task.Run(() =>
                {
                    foreach (PersonAnalysisDTO entity in entitiesList)
                    {
                        Mapper.CreateMap<PersonAnalysisDTO, PersonAnalysis>();
                        Database.PersonAnalyses.Add(Mapper.Map<PersonAnalysisDTO, PersonAnalysis>(entity));
                    }
                    Database.Save();
                });
        }
        public async Task UpdateEntityAsync(PersonAnalysisDTO entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public async Task DeleteEntityAsync(PersonAnalysisDTO entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

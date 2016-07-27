using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.DTO;
using CgemoHivTests.DataAccess.Interfaces;
using CgemoHivTests.DataAccess;
using AutoMapper;
using System.Linq.Expressions;

namespace CgemoHivTests.BusinessLogic.Services
{
    public class DeclarantService : IDbService<DeclarantDTO>
    {
        IUnitOfWork Database { get; set; }
        public DeclarantService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public DeclarantDTO GetEntity(int? id)
        {
            Mapper.CreateMap<Declarant, DeclarantDTO>();
            return Mapper.Map<Declarant, DeclarantDTO>(Database.Declarants.Get(id.Value));
        }
        public IEnumerable<DeclarantDTO> GetEntities()
        {        
            Mapper.CreateMap<Declarant, DeclarantDTO>();
            return Mapper.Map<IQueryable<Declarant>, List<DeclarantDTO>>(Database.Declarants.GetAll());
        }
        public IEnumerable<DeclarantDTO> FindBy(Expression<Func<DeclarantDTO, bool>> predicate)
        {
            Mapper.CreateMap<Expression<Func<DeclarantDTO, bool>>, Expression<Func<Declarant, bool>>>();
            Expression<Func<Declarant, bool>> predicateD = Mapper.Map<Expression<Func<DeclarantDTO, bool>>, Expression<Func<Declarant, bool>>>(predicate);

            Mapper.CreateMap<IQueryable<Declarant>, List<DeclarantDTO>>();
            return Mapper.Map<IQueryable<Declarant>, List<DeclarantDTO>>(Database.Declarants.FindeBy(predicateD));
        }
        public void SaveEntity(DeclarantDTO entity)
        {
            Mapper.CreateMap<DeclarantDTO, Declarant>();
            Database.Declarants.Add(Mapper.Map<DeclarantDTO, Declarant>(entity));
            Database.Save();
        }
        public void SaveEntities(IEnumerable<DeclarantDTO> entitiesList)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void UpdateEntity(DeclarantDTO entity)
        {
            Mapper.CreateMap<DeclarantDTO, Declarant>();
            Database.Declarants.Edit(Mapper.Map<DeclarantDTO, Declarant>(entity));
            Database.Save();
        }
        public void DeleteEntity(DeclarantDTO entity)
        {
            Mapper.CreateMap<DeclarantDTO, Declarant>();
            Database.Declarants.Delete(Mapper.Map<DeclarantDTO, Declarant>(entity));
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

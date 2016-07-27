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
    public class UpdateLogService : IDbService<UpdateLogDTO>
    {
        IUnitOfWork Database { get; set; }
        public UpdateLogService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public UpdateLogDTO GetEntity(int? id)
        {
            Mapper.CreateMap<UpdateLog, UpdateLogDTO>();
            return Mapper.Map<UpdateLog, UpdateLogDTO>(Database.UpdateLogs.Get(id.Value));
        }
        public IEnumerable<UpdateLogDTO> GetEntities()
        {
            Mapper.CreateMap<UpdateLog, UpdateLogDTO>();
            return Mapper.Map<IQueryable<UpdateLog>, List<UpdateLogDTO>>(Database.UpdateLogs.GetAll());
        }
        public IEnumerable<UpdateLogDTO> FindBy(Expression<Func<UpdateLogDTO, bool>> predicate)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
            //Mapper.CreateMap<Expression<Func<UpdateLogDTO, bool>>, Expression<Func<UpdateLog, bool>>>();
            //Expression<Func<UpdateLog, bool>> predicateD = Mapper.Map<Expression<Func<UpdateLogDTO, bool>>, Expression<Func<UpdateLog, bool>>>(predicate);

            //Mapper.CreateMap<IQueryable<UpdateLog>, List<UpdateLogDTO>>();
            //return Mapper.Map<IQueryable<UpdateLog>, List<UpdateLogDTO>>(Database.UpdateLogs.FindeBy(predicateD));
        }
        public void SaveEntity(UpdateLogDTO entity)
        {
            Mapper.CreateMap<UpdateLogDTO, UpdateLog>();
            Database.UpdateLogs.Add(Mapper.Map<UpdateLogDTO, UpdateLog>(entity));
            Database.Save();
        }
        public void SaveEntities(IEnumerable<UpdateLogDTO> entitiesList)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void UpdateEntity(UpdateLogDTO entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void DeleteEntity(UpdateLogDTO entity)
        {
            throw new NotImplementedException("Этот метод не поддерживается объектом");
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

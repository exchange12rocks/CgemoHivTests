using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CgemoHivTests.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PersonAnalysis> PersonAnalyses { get; }
        IRepository<Declarant> Declarants { get; }
        IRepository<UpdateLog> UpdateLogs { get; }
        IUserRepository<User> Users { get; }
        void Save();
    }
}

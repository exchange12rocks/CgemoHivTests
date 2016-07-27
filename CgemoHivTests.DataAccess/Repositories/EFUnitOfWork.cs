using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;

namespace CgemoHivTests.DataAccess.Repositories
{
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private CgemoHivTestsContext db;
        private IRepository<PersonAnalysis> personAnalysisRepository;
        private IRepository<Declarant> declarantRepository;
        private IRepository<UpdateLog> updateLogRepository;
        private IUserRepository<User> userRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new CgemoHivTestsContext(connectionString);
        }

        public IRepository<PersonAnalysis> PersonAnalyses
        {
            get
            {
                if (personAnalysisRepository == null)
                    personAnalysisRepository = new PersonAnalysisRepository(db);
                return personAnalysisRepository;
            }
        }
        public IRepository<Declarant> Declarants
        {
            get
            {
                if (declarantRepository == null)
                    declarantRepository = new DeclarantRepository(db);
                return declarantRepository;
            }
        }
        public IRepository<UpdateLog> UpdateLogs
        {
            get
            {
                if (updateLogRepository == null)
                    updateLogRepository = new UpdateLogRepository(db);
                return updateLogRepository;
            }
        }
        public IUserRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

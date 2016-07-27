﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CgemoHivTests.DataAccess.Interfaces;
using CgemoHivTests.DataAccess.Repositories;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.Services;

namespace CgemoHivTests.BusinessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
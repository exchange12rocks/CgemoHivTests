using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CgemoHivTests.BusinessLogic.Interfaces;
using CgemoHivTests.BusinessLogic.Services;
using CgemoHivTests.BusinessLogic.DTO;

namespace CgemoHivTests.WebUI.Util
{
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IDbServiceAsync<PersonAnalysisDTO>>().To<PersonAnalysisService>();
            kernel.Bind<IUserService<UserDTO>>().To<UserService>();         
        }
    }
}
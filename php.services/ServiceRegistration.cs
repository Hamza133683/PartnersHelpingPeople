using Ninject;
using php.EF;
using php.services.Implimentation;
using php.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.services
{
    public class ServiceRegistration
    {
        public static IKernel GlobalKernel
        {
            get; private set;
        }
        public static void BindAll(IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<PHPEntities>().ToSelf();
            GlobalKernel = kernel;
        }
    }
}

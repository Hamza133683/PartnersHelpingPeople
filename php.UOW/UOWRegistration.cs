using Ninject;
using php.services;
using php.UOW.Implimentation;
using php.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.UOW
{
    public class UOWRegistration
    {
        internal static IKernel GlobalKernel { get; private set; }
        public static void BindAll(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            ServiceRegistration.BindAll(kernel);
            GlobalKernel = kernel;
        }
    }
}

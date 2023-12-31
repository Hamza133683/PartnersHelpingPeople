using Ninject;
using php.services.Interface;
using php.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static php.UOW.UOWRegistration;

namespace php.UOW.Implimentation
{
    public class UnitOfWork:IUnitOfWork
    {
        public IAccountService Accounts => GlobalKernel.Get<IAccountService>();
    }
}

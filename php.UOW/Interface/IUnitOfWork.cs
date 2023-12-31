using php.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.UOW.Interface
{
    public interface IUnitOfWork
    {
        IAccountService Accounts { get; }
    }
}

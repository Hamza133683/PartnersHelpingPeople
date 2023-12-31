using php.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.services.Interface
{
    public interface IAccountService
    {
        bool Signup(Account _account, string _Password);
        Account Login(string _email, string _password);
    }
}

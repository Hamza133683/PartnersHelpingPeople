using php.common;
using php.DTO;
using php.EF;
using php.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php.services.Implimentation
{
    public class AccountService: IAccountService
    {
        private PHPEntities _db;

        public AccountService(PHPEntities db)
        {
            _db = db;
        }
        public bool Signup(Account _account,string _Password)
        {
            try
            {
                var checkaccount = _db.Accounts.Any(s=>s.Email==_account.Email);
                if(checkaccount)
                {

                }
                else
                {
                    _db.Accounts.Add(_account);
                    _db.SaveChanges();
                    var userrole =new UserRole(){

                        Email=_account.Email,
                        Password=_Password,
                        DateTime=DateTime.UtcNow,
                        AccountId=_account.AccountId,
                        UserRoleTypeId=1
                    };
                    _db.UserRoles.Add(userrole);
                    _db.SaveChanges();
                }
               
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Account Login(string _email, string _password)
        {
                var checkuser=_db.UserRoles.Where(s=>s.Email==_email&& s.Password==_password).FirstOrDefault();   
                if(checkuser == null) 
                {
                  PhpExceptions.Throw(ErrorCode.INVALID_EMAIL_OR_PASSWORD, null); 
                }
                var account = _db.Accounts.Where(s => s.AccountId == checkuser.AccountId).FirstOrDefault();
                return account;

        }
    }
}

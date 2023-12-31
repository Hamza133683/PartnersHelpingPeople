using php.common;
using php.DTO;
using php.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace php.CustomFilter
{
    public class PhpFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewResult view = new ViewResult();
            //view.ViewName = "~/Views/Account/Login.cshtml";
            view.ViewName = "~/Views/Account/Index.cshtml";
            if (SessionItems.Get(SessionKey.ACCOUNT) == null)
            {
                view.ViewBag.error = "Please login to continue";
                filterContext.Result = view;
            }
            else
            {
               /* var _ac = SessionItems.Get(SessionKey.ACCOUNT) as Account;
                using (PHPEntities _db = new PHPEntities())
                {
                    _ac = _db.Accounts.FirstOrDefault(x => x.AccountId == _ac.AccountId);
                    //SessionItems.Add(SessionKey.ACCOUNT, _ac);
                }
                if (_ac.AccountEnabled == false)
                {
                    SessionItems.RemoveAll();
                    view.TempData["msg"] = "Invalid Account";
                    filterContext.Result = view;
                }*/
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
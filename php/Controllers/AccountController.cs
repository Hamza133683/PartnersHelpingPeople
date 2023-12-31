using php.common;
using php.DTO;
using php.UOW.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace php.Controllers
{
    //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class AccountController : Controller
    {
        private IUnitOfWork _uow;

        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Account
        public ActionResult Index(string _email="")
        {
            ViewBag.Email = _email;
            return View();
        }
        [HttpPost]
        public ActionResult login(string _email,string _password)
        {
            try
            {
                var account = _uow.Accounts.Login(_email, _password);
                if(account == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                SessionItems.Add(SessionKey.ACCOUNT, account);
                return RedirectToAction("Index", "Dashboards");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message.ToString().Replace("_", " ");
                return RedirectToAction("Index", "Account");

            }

        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Account _account,HttpPostedFileBase _profilephoto,string _Password)
        {
            string filename = Path.GetFileNameWithoutExtension(_profilephoto.FileName);
            string extension = Path.GetExtension(_profilephoto.FileName);
            HttpPostedFileBase File = _profilephoto;
            filename = filename + extension;
            _account.ImageURL = "~/ProfilePhotos/" + filename;
            filename = Path.Combine(Server.MapPath("~/ProfilePhotos/"), filename);
            _profilephoto.SaveAs(filename);

            bool res=_uow.Accounts.Signup(_account,_Password);
            if(res)
            {
                return RedirectToAction("Index", new { _email = _account.Email });   
            }
            return View();
        }

        public ActionResult LogOut()
        {
            SessionItems.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}
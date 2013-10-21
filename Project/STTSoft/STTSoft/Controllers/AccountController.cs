using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTSoft.Models;

namespace STTSoft.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        STTSoftDataContext db = new STTSoftDataContext();

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.status = (string)TempData["error"];
            return PartialView("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Select the input usename in textbox at login form
            username = Request.Params["txtUsername"];
            // Select the input password in textbox at login form
            password = Request.Params["txtPassword"];
            try
            {
                var account = (from acc in db.Accounts
                               where acc.AccName.Equals(username) && acc.AccPass.Equals(password)
                               select acc).SingleOrDefault();

                //Kiểm tra username và password trong database
                if (account != null)
                {
                    Session["username"] = username;
                    Session["role"] = account.AccRole;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Tên đăng nhập or mật khẩu của bạn không đúng, Vui lòng nhập lại";
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw argumentNullException;
            }
        }

        //Đăng xuất
        [HttpGet]
        public ActionResult Logout()
        {
            return View();
        }


        public ActionResult Register()
        {
            return PartialView();
        }

        public ActionResult ForgetPass()
        {
            return View();
        }

        public ActionResult ChangePass()
        {
            return View();
        }

    }
}

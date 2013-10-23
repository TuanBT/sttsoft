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

            int id = 0;
            int quantity = 0;
            string dl;
            // Select the input usename in textbox at login form
            username = Request.Params["txtUsername"];
            // Select the input password in textbox at login form
            password = Request.Params["txtPassword"];
            try
            {

                var account = (from acc in db.Accounts
                               where acc.AccName.Equals(username) && acc.AccPass.Equals(password)
                               select acc).SingleOrDefault();
                //var accName = (from ac in db.Accounts where ac.AccRole == "D" select ac.AccName).Single();
                //Kiểm tra username và password trong database
                if (account != null)
                {
                    Dictionary<int, int> basket = (Dictionary<int, int>)Session["Cart"];
                    Dictionary<int, string> accDL = (Dictionary<int, string>)Session["AccDl"];
                    
                    if (basket != null)
                    {
                        //duyệt từng cắp các giá trị <key><value> trong basket
                        foreach (KeyValuePair<int, int> pair in basket)
                        {
                            //gán giá trị
                            dl = accDL[pair.Key];
                            var accRole = (from ac in db.Accounts where ac.AccName == dl select ac.AccRole).Single();
                            if (account.AccRole==accRole )
                            {
                                return View("ErrorPage3");
                            }
                            Session["username"] = username;
                            Session["role"] = account.AccRole;
                        }
                    }
                    return RedirectToAction("ShopingCart", "Cart");
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


        [HttpGet]
        public ActionResult Register(int error = 0)
        {
            // Kiểm tra tên đăng nhập hoặc email có tồn tại chưa
            if (error == 1)
            {
                ViewBag.Status = "Username or Email existed!";
            }
            else
            {
                ViewBag.Status = string.Empty;
            }
            return PartialView("Register");
        }

        //Đăng kí
        [HttpPost]
        public ActionResult Register(string sendEmail, string subject, string message)
        {
            ViewBag.Status = string.Empty;
            string username = Request.Params["username"];
            string password = Request.Params["password"];
            string role = Request.Params["optionsDl"];
            string name = Request.Params["name"];
            string email = Request.Params["sendEmail"];
            string phone = Request.Params["phone"];
            string action = Request.Params["Create"];
            if ("Tạo mới".Equals(action))
            {
                // Kiểm tra tên đăng nhập và email
                Account t = db.Accounts.FirstOrDefault(ac => ac.AccName.Equals(username) || ac.AccMail.Equals(email));
                //Nếu tên đăng nhập hoặc email tồn tại
                if (t != null)
                {
                    ViewBag.Status = "Username or Email existed!";
                    return RedirectToAction("Register", new { error = 1 });
                }
                else
                {
                    ViewBag.Status = string.Empty;
                    var account = new Account
                    {
                        AccName = username,
                        AccPass = password,
                        AccRole = role,
                        AccMail = email,
                        AccPhone = phone
                    };
                    try
                    {
                        db.Accounts.InsertOnSubmit(account);
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        return View("Register");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
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

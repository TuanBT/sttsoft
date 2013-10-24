using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                            return RedirectToAction("ShopingCart", "Cart");
                        }
                    }
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

        //Gửi email đăng kí
        public void SendEmail(string sendEmail, string subject, string message)
        {
            string email = "baoxanhvn@gmail.com";
            string password = "1234%^&*";

            var loginInfo = new NetworkCredential(email, password); var msg = new MailMessage(); var smtpClient = new SmtpClient

            ("smtp.gmail.com", 587);

            msg.From = new MailAddress(email); msg.To.Add(new MailAddress(sendEmail)); msg.Subject = subject; msg.Body = message;

            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true; smtpClient.UseDefaultCredentials = false; smtpClient.Credentials = loginInfo; smtpClient.Send

            (msg);
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

                    var accBank = new Bank
                    {
                        AccName = username,
                        BanMoney = Convert.ToDouble(0)
                    };
                    try
                    {
                        if (role.Equals("D"))
                        {
                            db.Banks.InsertOnSubmit(accBank);
                        }
                        db.Accounts.InsertOnSubmit(account);
                        SendEmail(sendEmail, subject, message);
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

        public ActionResult Account()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                var accountDetail = db.Accounts.Single(ac => ac.AccName == username);
                return View(accountDetail);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Account(string username)
        {
            try
            {
                username = Request.Params["username"];
                var account = db.Accounts.Single(ac => ac.AccName == username);
                string email = Request.Params["email"];
                string phone = Request.Params["phone"];
                string action = Request.Params["Edit"];
                if ("Save".Equals(action))
                {
                    account.AccMail = email;
                    account.AccPhone = phone;
                    db.SubmitChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
            }
            catch (NotImplementedException)
            {
                
                return View("Error");
            }
           
            return View();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTSoft.Models;
using STTSoft.STTSoftService;
namespace STTSoft.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        STTSoftDataContext db = new STTSoftDataContext();

        #region Product
        public ActionResult ProductList()
        {
            return View();
        }

        public ActionResult ProductInsert()
        {
            return View();
        }

        public ActionResult ProductEdit()
        {
            return View();
        }

        public ActionResult ProductDelete()
        {
            return View();
        }

        #endregion

        #region Catalog
        public ActionResult CatalogList()
        {
            return View();
        }

        public ActionResult CatalogInsert()
        {
            return View();
        }

        public ActionResult CatalogEdit()
        {
            return View();
        }

        public ActionResult CatalogDelete()
        {
            return View();
        }

        #endregion

        #region Account

        AdminServiceSoapClient service = new AdminServiceSoapClient();

        public ActionResult AccountList()
        {
            var listUser = service.AccountList().ToList();
            return View(listUser);
        }

        public ActionResult AccountInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountInsert(string txtName, string txtRole, string txtLevel, string txtMail, string txtPhone,string txtPass)
        {
            if (service.AccountInsert(txtName, txtRole, Convert.ToInt32(txtLevel), txtMail, txtPhone, txtPass))
            {
                return RedirectToAction("AccountList", "Admin");
            }
            //if false
            return View();
        }

        public ActionResult AccountEdit()
        {
            var accName = Request.QueryString["accName"];
            var account = db.Accounts.FirstOrDefault(a => a.AccName == accName);
            return View(account);
        }

        [HttpPost]
        public ActionResult AccountEdit(string txtName, string txtRole, int txtLevel, string txtMail, string txtPhone)
        {
            if(service.AccountEdit(txtName,txtRole,Convert.ToInt32(txtLevel),txtMail,txtPhone))
            {
                return RedirectToAction("AccountList", "Admin");
            }
            //if false
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccountDelete()
        {
            var accName = Request.QueryString["accName"];
            if(service.AccountDelete(accName))
            {
                return RedirectToAction("AccountList", "Admin");
            }
            //If false
            return View();
        }

        #endregion

        #region Order
        public ActionResult OrderList()
        {
            return View();
        }

        public ActionResult OrderDetail()
        {
            return View();
        }

        public ActionResult OrderEdit()
        {
            return View();
        }

        public ActionResult OrderDelete()
        {
            return View();
        }

        #endregion
    }
}

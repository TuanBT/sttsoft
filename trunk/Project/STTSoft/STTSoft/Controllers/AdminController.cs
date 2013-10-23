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
        AdminServiceSoapClient service = new AdminServiceSoapClient();

        #region Product
        public ActionResult ProductList()
        {
            var listProduct = service.ProductList().ToList();
            return View(listProduct);
        }

        public ActionResult ProductInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductInsert(string txtName, string txtDetail, string txtImage, double txtPrice)
        {
            if (service.ProductInsert(txtName, txtDetail, txtImage, Convert.ToDouble(txtPrice)))
            {
                return RedirectToAction("ProductList", "Admin");
            }
            return View();
        }

        public ActionResult ProductEdit()
        {
            int proId = Convert.ToInt32(Request.QueryString["proId"]);
            var product = db.Products.FirstOrDefault(p => p.ProId == proId);
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductEdit(int txtproId, string txtName, string txtDetail, string txtImage, double txtPrice)
        {
            if (service.ProductEdit(txtproId, txtName, txtDetail, txtImage, Convert.ToDouble(txtPrice)))
            {
                return RedirectToAction("ProductList", "Admin");
            }
            //if false
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ProductDelete()
        {
            int proId = Convert.ToInt32(Request.QueryString["proId"]);
            if (service.ProductDelete(proId))
            {
                return RedirectToAction("ProductList", "Admin");
            }
            //If false
            return View();
        }

        #endregion

        #region Catalog
        public ActionResult CatalogList()
        {
            var listCategory = service.CatalogList().ToList();
            return View(listCategory);
        }

        public ActionResult CatalogInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatalogInsert(string catName)
        {
            if (service.CatalogInsert(catName))
            {
                return RedirectToAction("CatalogList", "Admin");
            }
            return View();
        }

        public ActionResult CatalogEdit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatalogEdit(string catId,string catName)
        {
            if (service.CatalogEdit(Convert.ToInt32(catId), catName)) ;
            {
                return RedirectToAction("CatalogList", "Admin");
            }
            return View();
        }

        public ActionResult CatalogDelete()
        {
            int catId = Convert.ToInt32(Request.QueryString["catId"]);
            if (service.CatalogDelete(catId))
            {
                return RedirectToAction("CatalogList", "Admin");
            }
            //If false
            return View();
        }

        #endregion

        #region Account

       

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

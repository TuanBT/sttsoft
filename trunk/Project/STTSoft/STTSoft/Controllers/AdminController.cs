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
            var catId = Request.QueryString["catId"];
            var catalogList = db.Categories.FirstOrDefault(c => c.CatId == Convert.ToInt32(catId));
            return View(catalogList);
        }

        [HttpPost]
        public ActionResult CatalogEdit(string txtCatId, string txtCatName)
        {
            if (service.CatalogEdit(Convert.ToInt32(txtCatId), txtCatName))
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
            var accName = Request.QueryString["accName"];
            var listOrder = service.OrderList(accName).ToList();
            return View(listOrder);
        }

        public ActionResult OrderDetail()
        {
            return View();
        }

        public ActionResult OrderEdit()
        {
            var ordId = Request.QueryString["ordId"];
            var accName = Request.QueryString["accName"];
            var orOrdPro = (from or in db.Orders
                            join ord in db.OrderDetails on or.OrId equals ord.OrId
                            join pro in db.Products on ord.ProId equals pro.ProId
                            where or.AccName == accName
                            where ord.OrdId == Convert.ToInt32(ordId) 
                            select new OrOrdProModel()
                                       {
                                          Order = or,
                                          OrderDetail = ord,
                                          Product = pro
                                       }
                           ).Single();
            return View(orOrdPro);
        }

        [HttpPost]
          public ActionResult OrderEdit(string txtOrdId,string txtQantity)
        {
            if (service.OrderEdit(Convert.ToInt32(txtOrdId),Convert.ToInt32(txtQantity)))
            {
                return RedirectToAction("AccountList", "Admin");
            }
            //if false
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderDelete()
        {
            var ordId = Request.QueryString["ordId"];
            if (service.OrderDelete(Convert.ToInt32(ordId)))
            {
                return RedirectToAction("AccountList", "Admin");
            }
            //If false
            return View();
        }

        #endregion

        #region OrderDetail

        #endregion

        #region Bank
        public ActionResult BankList()
        {
            var listBank = service.BankList().ToList();
            return View(listBank);
        }

        public ActionResult BankEdit()
        {
            var accName = Request.QueryString["accName"];
            var bank = db.Banks.FirstOrDefault(b => b.AccName == accName);
            return View(bank);
        }

        [HttpPost]
        public ActionResult BankEdit(string txtAccName,string txtBankMoney)
        {
            if (service.BankEdit(txtAccName, Convert.ToDouble(txtBankMoney)))
            {
                return RedirectToAction("BankList", "Admin");
            }
            //if false
            return RedirectToAction("Index", "Home");
        }

        public ActionResult BankDelete()
        {
            var accName = Request.QueryString["accName"];
            if (service.BankDelete(accName))
            {
                return RedirectToAction("BankList", "Admin");
            }
            //If false
            return View();
        }
        #endregion
    }
}

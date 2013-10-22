using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTSoft.STTSoftService;
namespace STTSoft.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult AccountList()
        {
            var service = new AdminServiceSoapClient();
            var listUser = service.ListUser().ToList();
            return View(listUser);
        }

        public ActionResult AccountInsert()
        {
            return View();
        }

        public ActionResult AccountEdit()
        {
            return View();
        }

        public ActionResult AccountDelete()
        {
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

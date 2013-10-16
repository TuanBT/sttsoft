using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STTSoft.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult ShopingCart()
        {
            return View();
        }

    }
}

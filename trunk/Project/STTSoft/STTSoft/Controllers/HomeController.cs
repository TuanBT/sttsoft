using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTSoft.Models;
namespace STTSoft.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        STTSoftDataContext db = new STTSoftDataContext();
        public ActionResult Index()
        {
            var product = (from pro in db.Products select pro);
            ViewBag.Product = product.ToList<Product>();
            return View();
        }

        public ActionResult Detail(int proId = 0)
        {
            var proDetail = db.Products.Single(p => p.ProId == proId);
            ViewBag.ProDetail = proDetail;
            var comment = (from com in db.Comments where com.ProId == proId select com);
            ViewBag.list = comment.ToList<Comment>();
            return View("Detail");
        }
        public ActionResult GenreMenu()
        {
            var geners = db.Categories.ToList();
            return PartialView(geners);
        }
        public ActionResult LoadByCat(string category)
        {
            List<Category> categories = db.Categories.Where(cat => cat.CatName == category).ToList();
            if (categories.Count > 0)
            {
                var categoryModel = db.Categories.Single(cat => cat.CatName.ToLower() == category.ToLower());
                if (categoryModel != null)
                {
                    ViewBag.Category = categoryModel;
                }

                var catId = (from c in db.Categories where c.CatName == category select c.CatId).SingleOrDefault();
                if (catId != null)
                {
                    int intCatId = (int)catId;
                    var proByCatid = (from p in db.Products where p.CatId == intCatId select p);
                    ViewBag.ProByCatId = proByCatid.ToList<Product>();

                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult PostComment()
        {
            string proId = Request.Params["proId"];
            string content = Request.Params["txtComment"];
            var comment = new Comment();
            comment.ProId = Convert.ToInt32(proId);
            comment.ComContent = content;
            db.Comments.InsertOnSubmit(comment);
            db.SubmitChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult DetailKiot()
        {
            return View();
        }

        public ActionResult AddToCart()
        {
            Dictionary<int, int> basket = (Dictionary<int, int>)Session["Cart"];

            string proId = Request.Params["proId"];
            var quantity = Request.Params["cartQuantity"];

            if (quantity != null)
            {
                if (basket != null)
                {
                    if (basket.ContainsKey(Convert.ToInt32(proId)))
                    {
                        basket[Convert.ToInt32(proId)] = Convert.ToInt32(quantity);
                    }
                    else
                    {
                        basket.Add(Convert.ToInt32(proId), Convert.ToInt32(quantity));
                    }

                    Session["Cart"] = basket;
                }
                else
                {
                    Dictionary<int, int> cart = new Dictionary<int, int>();
                    cart.Add(Convert.ToInt32(proId), Convert.ToInt32(quantity));
                    Session["Cart"] = cart;
                }
            }

            return RedirectToAction("index", "Home");
        }
        public int GetCartQuantity()
        {
            Dictionary<int, int> basket = (Dictionary<int, int>)Session["Cart"];
            if (basket != null)
            {
                return basket.Count();
            }
            return 0;
        }
        public ActionResult BasketPartialView()
        {
            ViewBag.count = GetCartQuantity();
            return PartialView();
        }


    }
}

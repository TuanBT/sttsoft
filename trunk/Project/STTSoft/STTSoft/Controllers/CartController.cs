﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTSoft.Models;

namespace STTSoft.Controllers
{
    public class Prodetail
    {
        public int Id;
        public string Image;
        public string Name;
        public int Quantity;
        public DateTime time;
        public double Price;
        public double Total;
        public string DL;
    }

    public class CartController : Controller
    {
        //
        // GET: /Cart/
        STTSoftDataContext db = new STTSoftDataContext();
        public ActionResult ShopingCart()
        {
            int id = 0;
            int quantity = 0;
            string dl;
            //tạo list chứa danh sách sản phẩm
            List<Prodetail> list = new List<Prodetail>();
            //lưu biến basket với Session["Cart"]; 
            Dictionary<int, int> basket = (Dictionary<int, int>)Session["Cart"];
            Dictionary<int, string> accDL = (Dictionary<int, string>)Session["AccDl"];
            //nếu basket khác null
            if (basket != null)
            {
                //duyệt từng cắp các giá trị <key><value> trong basket
                foreach (KeyValuePair<int, int> pair in basket)
                {
                    //foreach (KeyValuePair<int, string> pair2 in accDL)
                    {
                        //gán giá trị
                        id = pair.Key;
                        quantity = pair.Value;
                        dl = accDL[pair.Key];

                        var listCartDetail = (from p in db.Products
                                              where p.ProId == id
                                              select new Prodetail()
                                              {
                                                  Id = p.ProId,
                                                  Image = p.ProImage,
                                                  Name = p.ProName,
                                                  Quantity = quantity,
                                                  time = DateTime.Now,
                                                  DL =dl,
                                                  Price = (float)p.ProPrice,
                                                  Total = (float)(p.ProPrice * quantity)
                                              }).SingleOrDefault();
                        //add vào list
                        list.Add(listCartDetail);
                
                    }
                  
                }
            }
            ViewBag.ListCartDetail = list;
            return View();
        }
        public ActionResult ManageCart()
        {
            string btn = Request.Params["btn"];
            string namebtn = btn.Split('.')[0];
            string valuebtn = btn.Split('.')[1];
            int id = Convert.ToInt32(valuebtn);
            string txtQuantity = Request.Params["txtQuantity" + id];
            int newQuantity = Convert.ToInt32(txtQuantity);
            if (namebtn.Equals("delete"))
            {
                Dictionary<int, int> basket1 = (Dictionary<int, int>)Session["Cart"];
                if (basket1.ContainsKey(id))
                {
                    basket1.Remove(id);
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (namebtn.Equals("Save"))
            {
                Dictionary<int, int> basket1 = (Dictionary<int, int>)Session["Cart"];
                if (basket1.ContainsKey(id))
                {
                    basket1[id] = newQuantity;
                }
                return Redirect(Request.UrlReferrer.ToString());
            }
            return RedirectToAction("index", "Home");
        }
        [HttpPost]
        public ActionResult CheckOut(string oid)
        {
            var order = new Order();
            int proId = 0;
            int quantity = 0;
            Dictionary<int, int> basket = (Dictionary<int, int>)Session["Cart"];          
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            string a= Request.Params["txtDL"];
            order.OrdSaler = Request.Params["txtDL"];
            order.AccName = Session["username"].ToString();
            order.OrDate = DateTime.Now;
            order.OrTotal = Convert.ToDecimal(Request.Params["txtTotal"]);
            db.Orders.InsertOnSubmit(order);
            db.SubmitChanges();
            var orid = (from o in db.Orders orderby o.OrId descending select o.OrId).First();
           
            if (basket != null)
            {
                foreach (KeyValuePair<int, int> pair in basket)
                {
                    var orderd = new OrderDetail();
                    proId = pair.Key;
                    quantity = pair.Value;
                    orderd.ProId = proId;
                    var product = db.Products.Single(p => p.ProId == proId);
                    orderd.OrdQuantity = quantity;
                    orderd.OrdId = Convert.ToInt32(orid);
                    orderd.OrdTotal = Convert.ToDouble(product.ProPrice * quantity);
                    orderd.OrId = orid;
                    db.OrderDetails.InsertOnSubmit(orderd);
                    db.SubmitChanges();
                }
            }
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

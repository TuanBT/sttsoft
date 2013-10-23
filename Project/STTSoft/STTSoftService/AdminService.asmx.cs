﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using STTSoftService.DTO;

namespace STTSoftService
{
    /// <summary>
    /// Summary description for AdminService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminService : System.Web.Services.WebService
    {
        STTSoftDataContext db = new STTSoftDataContext();


        [WebMethod]
        public List<AccountDTO> AccountList()
        {
            var listAccount =
                (from acc in db.Accounts
                 select new AccountDTO
                            {
                                AccName = acc.AccName,
                                AccLevel = acc.AccLevel,
                                AccMail = acc.AccMail,
                                AccPass = acc.AccPass,
                                AccPhone = acc.AccPhone,
                                AccRole = acc.AccRole

                            }).ToList();

            return listAccount;
        }

        [WebMethod]
        public bool AccountInsert(string accName, string accRole, int accLevel, string accMail, string accPhone, string accPass)
        {
            var account = new Account
                              {
                                  AccName = accName,
                                  AccRole = accRole,
                                  AccLevel = accLevel,
                                  AccMail = accMail,
                                  AccPhone = accPhone,
                                  AccPass = accPass
                              };

            try
            {
                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public bool AccountEdit(string accName, string accRole, int accLevel, string accMail, string accPhone)
        {
            var account = db.Accounts.FirstOrDefault(a => a.AccName == accName);
            if (account != null)
            {
                account.AccName = accName;
                account.AccRole = accRole;
                account.AccLevel = accLevel;
                account.AccMail = accMail;
                account.AccPhone = accPhone;
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [WebMethod]
        public bool AccountDelete(string accName)
        {
            var account = db.Accounts.FirstOrDefault(a => a.AccName == accName);
            try
            {
                if (account != null)
                {
                    db.Accounts.DeleteOnSubmit(account);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }



        [WebMethod]
        public List<ProductDTO> ProductList()
        {
            var listProduct =
                (from pro in db.Products
                 select new ProductDTO
                            {
                                ProName = pro.ProName,
                                ProId = pro.ProId,
                                ProDetail = pro.ProDetail,
                                ProImage = pro.ProImage,
                                ProPrice = pro.ProPrice,
                            }

                ).ToList();
            return listProduct;
        }

        [WebMethod]
        public bool ProductInsert(string proName, string proDetail, string proImage, double proPrice)
        {
            var maxId = Convert.ToInt32(db.Products.OrderByDescending(p => p.ProId).FirstOrDefault().ProId);
            var product = new Product()
            {
                ProId = maxId + 1,
                ProName = proName,
                ProDetail = proDetail,
                ProImage = proImage,
                ProPrice = proPrice
            };

            try
            {
                db.Products.InsertOnSubmit(product);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public bool ProductEdit(int proId, string proName, string proDetail, string proImage, double proPrice)
        {
            var product = db.Products.FirstOrDefault(p => p.ProId == proId);
            if (product != null)
            {
                product.ProName = proName;
                product.ProDetail = proDetail;
                product.ProImage = proImage;
                product.ProPrice = proPrice;
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [WebMethod]
        public bool ProductDelete(int proId)
        {
            var product = db.Products.FirstOrDefault(p => p.ProId == proId);
            if (product != null)
            {
                var listComment = db.Comments.Where(c => c.ProId == product.ProId);
                foreach (var comment in listComment)
                {
                    db.Comments.DeleteOnSubmit(comment);
                }
                var listOrderDetail = db.OrderDetails.Where(o => o.ProId == product.ProId);
                foreach (var orderDetail in listOrderDetail)
                {
                    db.OrderDetails.DeleteOnSubmit(orderDetail);
                }
                db.Products.DeleteOnSubmit(product);
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }



        [WebMethod]
        public List<CategoryDTO> CatalogList()
        {
            var listCategory =
                (from cat in db.Categories
                 select new CategoryDTO()
                 {
                     CatId = cat.CatId,
                     CatName = cat.CatName
                 }

                ).ToList();
            return listCategory;
        }

        [WebMethod]
        public bool CatalogInsert(string catName)
        {
            var maxId = Convert.ToInt32(db.Categories.OrderByDescending(c => c.CatId).FirstOrDefault().CatId);
            var category = new Category()
            {
                CatId = maxId + 1,
                CatName = catName,
            };

            try
            {
                db.Categories.InsertOnSubmit(category);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        [WebMethod]
        public bool CatalogEdit(int catId, string catName)
        {
            var category = db.Categories.FirstOrDefault(c => c.CatId == catId);
            if (category != null)
            {
                category.CatName = catName;
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        [WebMethod]
        public bool CatalogDelete(int catId)
        {
            var category = db.Categories.FirstOrDefault(c => c.CatId == catId);
            if (category != null)
            {
                var listproduct = db.Products.Where(p => p.CatId == category.CatId);
                foreach (var product in listproduct)
                {
                    db.Products.DeleteOnSubmit(product);
                    var listComment = db.Comments.Where(c => c.ProId == product.ProId);
                    foreach (var comment in listComment)
                    {
                        db.Comments.DeleteOnSubmit(comment);
                    }
                    var listOrderDetail = db.OrderDetails.Where(o => o.ProId == product.ProId);
                    foreach (var orderDetail in listOrderDetail)
                    {
                        db.OrderDetails.DeleteOnSubmit(orderDetail);
                    }
                }
                db.Categories.DeleteOnSubmit(category);
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}

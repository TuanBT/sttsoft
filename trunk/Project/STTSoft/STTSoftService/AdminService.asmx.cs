using System;
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

        #region Account
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
            foreach (var accountDto in listAccount)
            {
                var order = db.Orders.FirstOrDefault(o => o.AccName == accountDto.AccName);
                if (order != null)
                {
                    accountDto.IsOrder = true;
                }
            }
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
        #endregion

        #region Product
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
        #endregion

        #region Catalog
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
        #endregion

        #region Bank
        [WebMethod]
        public List<BankDTO> BankList()
        {
            var listBank =
               (from ban in db.Banks
                select new BankDTO()
                {
                    AccName = ban.AccName,
                    BanMoney = ban.BanMoney
                }

               ).ToList();
            return listBank;
        }

        [WebMethod]
        public bool BankEdit(string accName, double banMoney)
        {
            var bank = db.Banks.FirstOrDefault(b => b.AccName == accName);
            if (bank != null)
            {
                bank.BanMoney = banMoney;
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
        public bool BankDelete(string accName)
        {
            var bank = db.Banks.FirstOrDefault(b => b.AccName == accName);
            try
            {
                if (bank != null)
                {
                    db.Banks.DeleteOnSubmit(bank);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }
        #endregion

        #region order
        [WebMethod]
        public List<OrderDTO> OrderList(string accName)
        {
            var listOrder =
               (from or in db.Orders
                join ord in db.OrderDetails on or.OrId equals ord.OrId
                join pro in db.Products on ord.ProId equals pro.ProId
                where or.AccName == accName
                select new OrderDTO()
                {
                    AccName = or.AccName,
                    OrDate = or.OrDate,
                    OrId = or.OrId,
                    OrdId = ord.OrdId,
                    OrdQuantity = ord.OrdQuantity,
                    OrdSaler = ord.OrdSaler,
                    ProId = pro.ProId,
                    ProImage = pro.ProImage,
                    ProName = pro.ProName,
                    ProPrice = pro.ProPrice
                }

               ).ToList();
            return listOrder;
        }
        [WebMethod]
        public bool OrderEdit(int ordId, int ordQuantity)
        {
            var order = db.OrderDetails.FirstOrDefault(o => o.OrdId == ordId);
            if (order != null)
            {
                order.OrdQuantity = ordQuantity;
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
        public bool OrderDelete(int ordId)
        {
            var orderDetail = db.OrderDetails.FirstOrDefault(o => o.OrdId == ordId);
            try
            {
                if (orderDetail != null)
                {
                    var bank = db.Banks.FirstOrDefault(b => b.AccName == orderDetail.OrdSaler);
                    var proPrice = db.Products.FirstOrDefault(p => p.ProId == orderDetail.ProId).ProPrice;
                    if (bank != null)
                    {
                        bank.BanMoney = proPrice * orderDetail.OrdQuantity;
                    }
                    db.OrderDetails.DeleteOnSubmit(orderDetail);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }
        #endregion

        #region order Dai ly

        [WebMethod]
        public List<OrderDTO> OrderDaiLyList(string accName)
        {
            var listOrder =
               (from or in db.Orders
                join ord in db.OrderDetails on or.OrId equals ord.OrId
                join pro in db.Products on ord.ProId equals pro.ProId
                //where or.AccName == accName
                where ord.OrdSaler == accName
                select new OrderDTO()
                {
                    AccName = or.AccName,
                    OrDate = or.OrDate,
                    OrId = or.OrId,
                    OrdId = ord.OrdId,
                    OrdQuantity = ord.OrdQuantity,
                    OrdSaler = ord.OrdSaler,
                    ProId = pro.ProId,
                    ProImage = pro.ProImage,
                    ProName = pro.ProName,
                    ProPrice = pro.ProPrice
                }

               ).ToList();
            return listOrder;
        }
        #endregion

        #region comment
        [WebMethod]
        public bool CommentDelete(int comId=0)
        {
            var comment = db.Comments.FirstOrDefault(c => c.ComId == comId);
            try
            {
                if (comment != null)
                {
                    db.Comments.DeleteOnSubmit(comment);
                    db.SubmitChanges();
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
        }
        #endregion
    }
}

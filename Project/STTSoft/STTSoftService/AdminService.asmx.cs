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

        //public string AccName { get; set; }
        //public string AccRole;
        //public System.Nullable<int> AccLevel;
        //public string AccMail;
        //public string AccPhone;
        //public string AccPass;

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

            return  listAccount;
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
            var account = db.Accounts.FirstOrDefault(a=>a.AccName==accName);
            if(account!=null)
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
                if(account!=null)
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
    }
}

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
        

        [WebMethod]
        public List<AccountDTO> ListUser()
        {
            var db = new STTSoftDataContext();
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
    }
}

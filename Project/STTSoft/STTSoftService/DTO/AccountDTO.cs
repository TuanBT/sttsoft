using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STTSoftService.DTO
{
    public class AccountDTO
    {
        public string AccName { get; set; }

        public string AccRole;

        public System.Nullable<int> AccLevel;

        public string AccMail;

        public string AccPhone;

        public string AccPass;

        public bool IsOrder;
    }
}
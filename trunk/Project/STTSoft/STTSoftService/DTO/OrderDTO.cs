using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STTSoftService.DTO
{
    public class OrderDTO
    {
        public int OrId;
        public string AccName;
        public System.Nullable<System.DateTime> OrDate;
        public int OrdId;
        public System.Nullable<int> ProId;
        public System.Nullable<int> OrdQuantity;
        public string OrdSaler;
        public string ProName;
        public string ProImage;
        public double ProPrice;
    }
}
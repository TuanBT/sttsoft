using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STTSoft.Models
{
    public class OrOrdProModel
    {
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }
    }
}
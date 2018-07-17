using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ORDERS
    {
        public int ORDERNUM { get; set; }
        public int CUSTID { get; set; }
        public System.DateTime OREDERDATE { get; set; }
        public System.DateTime DELIVERYDATE { get; set; }
        public int ORDERTOTAL { get; set; }
    }
}

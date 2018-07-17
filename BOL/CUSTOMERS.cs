using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class CUSTOMERS
    {
        ////list of customers address
        //public List<CUSTOMERADDRESS> address = new List<CUSTOMERADDRESS>();
        //// list of Customers orders
        //public List<ORDERS> orders = new List<ORDERS>();

        public int CUSTID { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public long PHONE { get; set; }
        public List<CUSTOMERADDRESS> ADDRESS { get; set; }
        public List<ORDERS> ORDERS { get; set; }
    }
}

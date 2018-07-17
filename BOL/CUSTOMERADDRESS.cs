using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
public  class CUSTOMERADDRESS
    {
        public int ADDRESSID { get; set; }
        public int CUSTID { get; set; }
        public string STREET { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; }
        public int PINCODE { get; set; }


        //public override string ToString()
        //{
        //    return (this.CUSTID + " " + this.ADDRESSID + " " + this.DISTRICT);
        //}
    }

}

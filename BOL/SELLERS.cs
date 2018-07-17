using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class SELLERS
    {
        public int SELLERID { get; set; }
        public string SELLERNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public long PHONE { get; set; }
        public List<SELLERSADDRESS> ADDRESS { get; set; }
        public List<PURCHASES> PURCHASES { get; set; }
    }
}

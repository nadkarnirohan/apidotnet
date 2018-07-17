using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    public class Seller_ViewBLL
    {

        public static List<SELLERS_VIEW> GetSeller() => SELLERS_VIEWDAL.GetAll();

        public static IEnumerable<SELLERS_VIEW> GetSeller(string email)
        {
            List<SELLERS_VIEW> list = SELLERS_VIEWDAL.GetAll();

            var seller = from s in list where s.EMAIL.Equals(email) select s;

            return seller;
        }
    }
}

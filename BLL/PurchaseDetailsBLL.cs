using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    public class PurchaseDetailsBLL
    {
        public static List<PURCHASEDETAILS> GetAllPurchaseDetails() => PURCHASEDETAILSDAL.GetAll();

        public static IEnumerable<PURCHASEDETAILS> GetPurchaseDetail(int purchaseNo)
        {
          IEnumerable<PURCHASEDETAILS> list =PURCHASEDETAILSDAL.GetAll();
            var purchaseDetails = from pd in list where pd.PURCHASENO.Equals(purchaseNo) select pd;

            return purchaseDetails;
        }

        public static bool InsertPurchaseDetails(PURCHASEDETAILS purchaseDetails) => PURCHASEDETAILSDAL.InsertPurchaseDetails(purchaseDetails);
    }
}

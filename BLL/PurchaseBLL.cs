using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BOL;
using MarketDAL;
namespace BLL
{
    public class PurchaseBLL
    {
        //crudoperations

        //1 get purchase details using sellerid
        public static IEnumerable<PURCHASES> GetSellerPurchase(int sellerid)
        {
            IEnumerable<PURCHASES> purchases= PURCHASESDDAL.GetAll();
            var list = from p in purchases where p.SELLERID.Equals(sellerid)select p;
            return list;
        }
        //2 getAll purchase
        public static List<PURCHASES> GetPuchases() => PURCHASESDDAL.GetAll();        
        //4 insert purchase
        public static bool InsertCustomer(PURCHASES product) => PURCHASESDDAL.InsertPurchase(product);
       
        
        
        // 5 update customer
     //   public static bool UpdateCustomer(PURCHASES product) => PURCHASESDDAL.UpdateProduct(product);
        //6 delete customer
       // public static bool DeleteCustomer(int productID) => PURCHASESDDAL.d(productID);

        //special operations
    }
}

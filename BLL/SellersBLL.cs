using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    public class SellersBLL
    {
        //crudoperations

        //1 get customer details using name
        public static SELLERS GetSeller(int sellerId) => SELLERSDAL.Get(sellerId);

        //2 get customer details using email
        public static SELLERS GetSeller(string sellerEmail) => SELLERSDAL.Get(sellerEmail);

        //3 getAll SELLERS
        public static List<SELLERS> GetSellers() => SELLERSDAL.GetAll();

        //4 insert customer
        public static bool InsertSeller(SELLERS seller) => SELLERSDAL.InsertSeller(seller);

        // 5 update customer
        public static bool UpdateSeller(SELLERS seller) => SELLERSDAL.UpdateSeller(seller);

        //6 delete customer
        public static bool DeleteSeller(int sellerId) => SELLERSDAL.DeleteSeller(sellerId);

        //special operations
        public static SELLERS SellerAllData(int id)
        {
            SELLERS seller = null;
            try
            {
                seller = SELLERSDAL.Get(id);
                seller.ADDRESS = SELLERSADDRESSDAL.GetAll(id);
                seller.PURCHASES = PURCHASESDDAL.GetPurchase(id);
            }
            catch (NullReferenceException nex)
            {

                seller.ADDRESS = new List<SELLERSADDRESS>();
                seller.PURCHASES = new List<PURCHASES>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seller;
        }

        public static IEnumerable<PURCHASEDETAILS> SellerOrderDetails(int sellerId)
        {

            List<PURCHASES> purchases = PURCHASESDDAL.GetPurchase(sellerId);
            List<PURCHASEDETAILS> purchaseDetails = PURCHASEDETAILSDAL.GetAll();
           
            foreach(PURCHASES ps in purchases)
            {
                var details = from pd in purchaseDetails where pd.PURCHASENO.Equals(ps.PURCHASENO) select pd;
                return details;
            }

            return new List<PURCHASEDETAILS>();
        }
    }
}

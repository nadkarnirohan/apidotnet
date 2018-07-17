using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using MarketDAL;

namespace BLL
{
    public class SellerAddressBLL
    {
        //crudoperations

        //1 get customer details using id
        public static List<SELLERSADDRESS> GetAddresses(int sellerID) => SELLERSADDRESSDAL.GetAll(sellerID);
        //2  getAll customers
        public static List<SELLERSADDRESS> GetALLAddress() => SELLERSADDRESSDAL.GetAll();
        //4 insert customer
        public static bool InsertAddress(SELLERSADDRESS address) => SELLERSADDRESSDAL.InsertCustomerAddress(address);
        // 5 update customer
        public static bool UpdateAddress(SELLERSADDRESS address) => SELLERSADDRESSDAL.UpdateCustomerAddress(address);
        //6 delete customer
        public static bool DeleteAddress(int addressID) => SELLERSADDRESSDAL.DeleteAddress(addressID);

        //special operations

    }
}

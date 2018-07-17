using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarketDAL;
using BOL;
namespace BLL
{
      public class CustomerAddressBLL
    {
        //crudoperations

        //1 get customer details using name
        public static List<CUSTOMERADDRESS> GetAddresses(int customerId) => CUSTOMERADDRESSDAL.GetAddress(customerId);
        //2  getAll customers
        public static List<CUSTOMERADDRESS> GetAllAddress() => CUSTOMERADDRESSDAL.GetAll();
        //4 insert customer
        public static bool InsertAddress(CUSTOMERADDRESS address) => CUSTOMERADDRESSDAL.InsertCustomerAddress(address);
        // 5 update customer
        public static bool UpdateAddress(CUSTOMERADDRESS address) => CUSTOMERADDRESSDAL.UpdateCustomerAddress(address);
        //6 delete customer
        public static bool DeleteAddress(int addressID) => CUSTOMERADDRESSDAL.DeleteAddress(addressID);

        //special operations
    }
}

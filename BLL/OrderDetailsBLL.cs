using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    public class OrderDetailsBLL
    {
        //crudoperations

        //1 get customer details using name
        public static List<ORDERDETAILS> GetOrdeDetails(int orderNum) => ORDERDETAILSDAL.Get(orderNum);

        //2  getAll customers
        public static List<ORDERDETAILS> GetAllOrderDetails() => ORDERDETAILSDAL.GetAll();
        //4 insert customer
        public static bool InsertOrderDetails(ORDERDETAILS details) => ORDERDETAILSDAL.InsertOrderDetails(details);
        

        //special operations
    }
}

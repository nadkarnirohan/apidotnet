using System.Collections.Generic;

using BOL;
using MarketDAL;

namespace BLL
{
    public class OrdersBLL
    {
        //crudoperations

        //1 get customer details using name
        public static List<ORDERS> GetOrders(int custID) => ORDERSDAL.GetOrders(custID);

        //2  getAll customers
        public static List<ORDERS> GetAllOrders() => ORDERSDAL.GetAll();
        //4 insert customer
        public static bool InsertOrder(ORDERS order) => ORDERSDAL.InsertOrder(order);

        //special operations
    }
}

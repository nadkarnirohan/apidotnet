using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using MarketDAL;

namespace BLL
{
   public class CustomerBLL
    {
        //crudoperations
        
        //1 get customer details using name
        public static CUSTOMERS GetCustomer(int customerId) => CUSTOMERSDAL.Get(customerId);

        //2 get customer details using email
        public static CUSTOMERS GetCustomer(string customerEmail) => CUSTOMERSDAL.Get(customerEmail);

        //3 getAll customers
        public static List<CUSTOMERS> GetCustomers() => CUSTOMERSDAL.GetAll();
        
        //4 insert customer
        public static bool InsertCustomer(CUSTOMERS customer) => CUSTOMERSDAL.InsertCustomer(customer);
        
        // 5 update customer
        public static bool UpdateCustomer(CUSTOMERS customer) => CUSTOMERSDAL.UpdateCustomer(customer);
        
        //6 delete customer
        public static bool DeleteCustomer(int CustomerId) => CUSTOMERSDAL.DeleteCustomer(CustomerId);

        //special operations
        public static CUSTOMERS CustomerAllData(int id)
        {
            CUSTOMERS customer = null;
            try
            {
                customer= CUSTOMERSDAL.Get(id);
                customer.ADDRESS = CUSTOMERADDRESSDAL.GetAddress(id);
                customer.ORDERS = ORDERSDAL.GetOrders(id);
            }
            catch(NullReferenceException nex)
            {

                customer.ADDRESS = new List<CUSTOMERADDRESS>();
                customer.ORDERS = new List<ORDERS>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return customer;
        }

        public static List<ORDERDETAILS> CustomerOrderDetails(int custid)
        {

            List<ORDERS> orders = ORDERSDAL.GetOrders(custid);
            List<ORDERDETAILS> orderdetails = ORDERDETAILSDAL.GetAll();
           List<ORDERDETAILS> details = new List <ORDERDETAILS>();
             
            foreach (ORDERS o in orders)
            {
                foreach(ORDERDETAILS detail in orderdetails)
                {

                    if (o.ORDERNUM == detail.ORDERNUM)
                    {
                        details.Add(detail);
                    }
                }
                
            }

            return details;
            
        }
    }


   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BOL;
using BLL;

namespace API.Controllers
{
    public class CustomersController : ApiController
    {
        // GET: api/Customers
        public List<CUSTOMERS> Get()
        {
            return CustomerBLL.GetCustomers();
        }

        // GET: api/Customers/5
        public CUSTOMERS Getid(int id)
        {
            return CustomerBLL.GetCustomer(id);
        }
        // GET: api/Customers/?email=value
        public CUSTOMERS Get([FromUri]string email)
        {
            return CustomerBLL.GetCustomer(email);
        }

        // POST: api/Customers
        public bool Post([FromBody]CUSTOMERS customer)
        {
            return CustomerBLL.InsertCustomer(customer);
        }

        // PUT: api/Customers/
        public bool Put([FromBody]CUSTOMERS customer)
        {
            return CustomerBLL.UpdateCustomer(customer);
        }

        // DELETE: api/Customers/5
        public bool Delete(int id)
        {
            return CustomerBLL.DeleteCustomer(id);
        }

      //will require special routing 
        public List<ORDERDETAILS> GetOrderDetails(int custid)
        {
            return CustomerBLL.CustomerOrderDetails(custid);
        }

        public CUSTOMERS GetAllData(int custid)
        {
            return CustomerBLL.CustomerAllData(custid);
        }
    }
}

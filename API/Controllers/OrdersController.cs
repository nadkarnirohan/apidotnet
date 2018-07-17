using BLL;
using BOL;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IEnumerable<ORDERS> Get() => OrdersBLL.GetAllOrders();

        // GET: api/Orders/5
        public IEnumerable<ORDERS> Get(int id) => OrdersBLL.GetOrders(id);

        // POST: api/Orders
        public bool Post([FromBody]ORDERS order) => OrdersBLL.InsertOrder(order);

        //// PUT: api/Orders/
        //public void Put([FromBody]string value)=> OrdersBLL.
        //// DELETE: api/Orders/5
        //public void Delete(int id)
        //{
        //}
    }
}
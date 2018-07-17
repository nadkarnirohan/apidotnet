using BLL;
using BOL;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class OrderDetailsController : ApiController
    {
        // GET: api/OrderDetails
        public IEnumerable<ORDERDETAILS> Get() => OrderDetailsBLL.GetAllOrderDetails();

        // GET: api/OrderDetails/5
        public IEnumerable<ORDERDETAILS> Get(int id) => OrderDetailsBLL.GetOrdeDetails(id);

        // POST: api/OrderDetails
        public bool Post([FromBody]ORDERDETAILS details) => OrderDetailsBLL.InsertOrderDetails(details);

        //// PUT: api/OrderDetails/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/OrderDetails/5
        //public void Delete(int id)
        //{
        //}
    }
}
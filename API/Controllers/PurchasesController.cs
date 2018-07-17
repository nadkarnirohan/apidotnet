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
    public class PurchasesController : ApiController
    {
        // GET: api/Purchase
        public IEnumerable<PURCHASES> Get()
        {
            return PurchaseBLL.GetPuchases();
        }

        // GET: api/Purchase/5
        public IEnumerable<PURCHASES> Get(int id)
        {
            return PurchaseBLL.GetSellerPurchase(id);
        }

        // POST: api/Purchase
        public bool Post([FromBody]PURCHASES purchase)
        {
            return PurchaseBLL.InsertCustomer(purchase);
        }

        // PUT: api/Purchase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Purchase/5
        public void Delete(int id)
        {
        }
    }
}

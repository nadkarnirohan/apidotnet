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
    public class PurchaseDetailsController : ApiController
    {
        // GET: api/PurchaseDetails
        public IEnumerable<PURCHASEDETAILS> Get()
        {
            return PurchaseDetailsBLL.GetAllPurchaseDetails();
        }

        // GET: api/PurchaseDetails/5
        public IEnumerable<PURCHASEDETAILS> Get(int id)
        {
            return PurchaseDetailsBLL.GetPurchaseDetail(id);
        }

        // POST: api/PurchaseDetails
        public bool Post([FromBody] PURCHASEDETAILS details)
        {
            return PurchaseDetailsBLL.InsertPurchaseDetails(details);
        }

    }
}

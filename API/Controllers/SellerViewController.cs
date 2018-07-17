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
    public class SellerViewController : ApiController
    {
        // GET: api/SellerView
        public IEnumerable<SELLERS_VIEW> Get()
        {
            return Seller_ViewBLL.GetSeller();
        }

        // GET: api/SellerView/?email=
        public IEnumerable<SELLERS_VIEW> Get([FromUri]string email)
        {
            return Seller_ViewBLL.GetSeller(email);
        }

     
    }
}

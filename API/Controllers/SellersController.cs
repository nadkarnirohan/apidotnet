using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using BLL;
using BOL;

namespace API.Controllers
{
    public class SellersController : ApiController
    {
        // GET: api/Sellers
        public IEnumerable<SELLERS> Get()
        {
            return SellersBLL.GetSellers(); 
        }

        // GET: api/Sellers/5
        public SELLERS Get(int id)
        {
            return SellersBLL.GetSeller(id);
        }

        // GET: api/Sellers/?email=value
        public SELLERS Get([FromUri]string email)
        {
            return SellersBLL.GetSeller(email);
        }

        // POST: api/Sellers
        public bool Post([FromBody]SELLERS seller)
        {
            return SellersBLL.InsertSeller(seller);
        }

        // PUT: api/Sellers/5
        public bool Put([FromBody]SELLERS seller)
        {
            return SellersBLL.UpdateSeller(seller);
        }

        // DELETE: api/Sellers/5
        public bool Delete(int id)
        {
            return SellersBLL.DeleteSeller(id);
        }

        //special

        public IEnumerable<PURCHASEDETAILS>GetOrderDetails(int sellerid)
        {
            return SellersBLL.SellerOrderDetails(sellerid);
        }

        public SELLERS GetAllData(int sellerid)
        {
            return SellersBLL.SellerAllData(sellerid);
        }
    }
}

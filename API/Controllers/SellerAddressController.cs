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
    public class SellerAddressController : ApiController
    {
        // GET: api/SellerAddress
        public IEnumerable<SELLERSADDRESS> Get()
        {
            return SellerAddressBLL.GetALLAddress();
        }

        // GET: api/SellerAddress/5
        public IEnumerable<SELLERSADDRESS> Get(int id)
        {
            return SellerAddressBLL.GetAddresses(id);
        }

        // POST: api/SellerAddress
        public bool Post([FromBody]SELLERSADDRESS selleraddress)
        {
            return SellerAddressBLL.InsertAddress(selleraddress);
        }

        // PUT: api/SellerAddress/5
        public bool Put([FromBody]SELLERSADDRESS selleraddress)
        {
            return SellerAddressBLL.UpdateAddress(selleraddress);
        }

        // DELETE: api/SellerAddress/5
        public bool Delete(int id)
        {
            return SellerAddressBLL.DeleteAddress(id);
        }
    }
}

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
    public class CustomerAddressController : ApiController
    {
        // GET: api/CustomerAddress
        public IEnumerable<CUSTOMERADDRESS> Get() => CustomerAddressBLL.GetAllAddress();
        // GET: api/CustomerAddress/5
        public IEnumerable<CUSTOMERADDRESS> Get(int id) => CustomerAddressBLL.GetAddresses(id);

        // POST: api/CustomerAddress
        public bool Post([FromBody]CUSTOMERADDRESS address) => CustomerAddressBLL.InsertAddress(address);

        // PUT: api/CustomerAddress/5
        public bool Put([FromBody]CUSTOMERADDRESS address) => CustomerAddressBLL.UpdateAddress(address);

        // DELETE: api/CustomerAddress/5
        public bool Delete(int id) => CustomerAddressBLL.DeleteAddress(id);
        
    }
}

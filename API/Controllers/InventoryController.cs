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
    public class InventoryController : ApiController
    {
        // GET: api/Inventory
        public IEnumerable<INVENTORY> Get()
        {
            return InventoryBLL.GetALLInventory();
        }

       
    }
}

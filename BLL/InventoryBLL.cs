using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    //only admin 

    public class InventoryBLL
    {
        public static List<INVENTORY> GetALLInventory() => INVENTORYDAL.GetAll();
       
    }
}

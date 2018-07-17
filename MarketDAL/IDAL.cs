using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDAL
{
    interface IDAL
    {
        IEnumerable<IDAL> GetAll();
        IDAL Get(int id);
        bool Insert(IDAL obj);
        bool Update(IDAL obj);
        bool Delete(int id);

    }
}

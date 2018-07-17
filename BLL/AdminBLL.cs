using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;


namespace BLL
{
    //surperuser
    public class AdminBLL
    {
        public static List<ADMIN> GetAllAdmins() => ADMINDAL.GetAdmins();
        public static ADMIN GetAdmins(int adminId) => ADMINDAL.GetAdmin(adminId);
        public static ADMIN GetAdmin(string name)
        {
            List<ADMIN>  admins = ADMINDAL.GetAdmins();
            foreach(ADMIN admin in admins)
            {
                if (admin.ADMINNAME.Equals(name))
                {
                    return admin;
                }
            }
             return null;
        }
        

        public static bool InsertAdmin(ADMIN admin) => ADMINDAL.InsertAdmin(admin);
        public static bool UpdateAdmin(ADMIN admin) => ADMINDAL.UpdateAdmin(admin);
        public static bool DeleteAdmins(int adminId) => ADMINDAL.DeleteAdmin(adminId);


    }
}

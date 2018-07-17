using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using BOL;
using MarketDAL;
using BLL;

namespace API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Authentication" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Authentication.svc or Authentication.svc.cs at the Solution Explorer and start debugging.


    public class Authentication : IAuthentication
    {
        public CLAIM AuthenticateUser( string email,string password)
        {
            CLAIM customer = CLAIMDAL.GetClaim(email);

            if (customer.EMAIL == email && customer.PASSWORD == password)
            {
                return customer;
            }
            else return null;
        }

        public SELLERS AuthenticateSeller(string email, string password)
        {
            SELLERS seller = SELLERSDAL.Get(email);

            if (seller.EMAIL == email && seller.PASSWORD == password)
            {
                return seller;
            }
            else return null;
        }

        public ADMIN AuthenticateAdmin(string name, string password)
        {
            ADMIN admin = AdminBLL.GetAdmin(name);

            if (admin.ADMINNAME == name && admin.PASSWORD == password)
            {
                return admin;
            }
            else return null;
        }


        public void DoWork()
        {
            return;
        }
    }
}

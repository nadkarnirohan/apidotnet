using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.ServiceReference1;
using BOL;
using MarketDAL;
using API.Models;
namespace API.Controllers
{

    //[AllowCrossSite]
    public class ClaimController : ApiController
    {

        // GET: api/Claim/5

        public CLAIM Get([FromUri]string email)
        {
            return CLAIMDAL.GetClaim(email);
        }

        public SELLERS_VIEW Post([FromBody]Model claim)
        {
            Authentication authentication = new Authentication();

            SELLERS user = authentication.AuthenticateSeller(claim.EMAIL, claim.PASSWORD);

            SELLERS_VIEW seller = new SELLERS_VIEW();
            seller.EMAIL = user.EMAIL;
            seller.SELLERID = user.SELLERID;
            seller.SELLERNAME = user.SELLERNAME;

            return seller;
        }


        [Route("{login}")]
        [HttpPost]
        public CLAIM Login([FromBody]Model claim)
        {
            Authentication authentication = new Authentication();

           CLAIM user = authentication.AuthenticateUser(claim.EMAIL, claim.PASSWORD);

            return user;
        }

      

    }
}

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
    public class AdminController : ApiController
    {
        // GET: api/Admin
        public IEnumerable<ADMIN> Get() => AdminBLL.GetAllAdmins();

        // GET: api/Admin/5
        public ADMIN Get(int id)=> AdminBLL.GetAdmins(id);

        public ADMIN Get([FromUri]string name) => AdminBLL.GetAdmin(name);
        // POST: api/Admin
        public ADMIN Post([FromBody]ADMIN claim) {

            Authentication authentication = new Authentication();

            ADMIN admin = authentication.AuthenticateAdmin(claim.ADMINNAME, claim.PASSWORD);

            return admin;
        }      // => AdminBLL.InsertAdmin(admin);

        // PUT: api/Admin/5
        public bool Put([FromBody]ADMIN admin) => AdminBLL.UpdateAdmin(admin);


        // DELETE: api/Admin/5
        public void Delete(int id) => AdminBLL.DeleteAdmins(id);
    }
}

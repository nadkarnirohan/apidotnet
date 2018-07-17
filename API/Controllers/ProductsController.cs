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
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public IEnumerable<PRODUCTS> Get() => ProductsBLL.GetAllProducts();

        // GET: api/Products/5
        public IEnumerable<PRODUCTS> Get(int id) => ProductsBLL.GetProduct(id);

        // POST: api/Products
        public bool Post([FromBody]PRODUCTS product) => ProductsBLL.InsertProduct(product);

        // PUT: api/Products/5
        public bool Put([FromBody]PRODUCTS product) => ProductsBLL.UpdateProduct(product);

        // DELETE: api/Products/5
        public bool Delete(int id) => ProductsBLL.DeleteProduct(id);
    }
}

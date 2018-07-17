using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BOL;
using MarketDAL;

namespace BLL
{
    //only ADMIN
   public class ProductsBLL
    {
        //crudoperations

        //1 get product details using name
        public static PRODUCTS GetProducts(string ProductName) => PRODUCTSDAL.Get(ProductName);
       // 2 get product details using id
        public static IEnumerable<PRODUCTS> GetProduct(int productNo)
        {
            IEnumerable<PRODUCTS> products = PRODUCTSDAL.GetAll();
            var product = from prod in products where prod.PRODUCTNO.Equals(productNo) select prod;
            return product;
        }
        //3 getAll customers
        public static List<PRODUCTS> GetAllProducts() => PRODUCTSDAL.GetAll();
        //4 insert customer
        public static bool InsertProduct(PRODUCTS product) => PRODUCTSDAL.InsertProduct(product);
        // 5 update customer
        public static bool UpdateProduct(PRODUCTS product) => PRODUCTSDAL.UpdateProduct(product);
        //6 delete customer
        public static bool DeleteProduct(int productNo) => PRODUCTSDAL.DeleteProduct(productNo);

        //special operations
    }
}

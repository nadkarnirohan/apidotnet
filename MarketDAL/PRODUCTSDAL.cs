using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using Oracle.ManagedDataAccess.Client;
using System.Configuration;


using BOL;

namespace MarketDAL
{
  public class PRODUCTSDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;
        public static List<PRODUCTS> GetAll()
        {
            PRODUCTS product = null;
            List<PRODUCTS> products = new List<PRODUCTS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PRODUCTS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                product = new PRODUCTS()
                                {
                                    PRODUCTNAME = reader["PRODUCTNAME"].ToString(),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),

                                };
                                products.Add(product);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }

        public static PRODUCTS Get(string productname)
        {
            PRODUCTS product = null;
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PRODUCTS WHERE PRODUCTNAME =:productname";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":productname", productname));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                product = new PRODUCTS()
                                {
                                  PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                  PRODUCTNAME = reader["PRODUCTNAME"].ToString(),
                                };
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            { throw ex; }
            return product;
        }
        public static bool InsertProduct(PRODUCTS product)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO PRODUCTS (PRODUCTNAME) " +
                        "VALUES (:productname)";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":productname", product.PRODUCTNAME));
    
                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public static bool UpdateProduct(PRODUCTS product)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE PRODUCTS SET PRODUCTNAME= :productname where PRODUCTNO = :productno";
                
                    OracleCommand cmd = new OracleCommand(query, connection);
            
                    cmd.Parameters.Add(new OracleParameter(":productname", product.PRODUCTNAME));
                    cmd.Parameters.Add(new OracleParameter(":productno", product.PRODUCTNO));
                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public static bool DeleteProduct(int productId)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "DELETE FROM PRODUCTS WHERE PRODUCTNO = :productId";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":productId", productId));

                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

    }
}

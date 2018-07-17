using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

using BOL;

namespace MarketDAL
{
    public class PURCHASESDDAL
    {
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;

        public static List<PURCHASES> GetAll()
        {
            PURCHASES purchase = null;
            List<PURCHASES> purchases = new List<PURCHASES>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PURCHASES";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                purchase = new PURCHASES()
                                {
                                    PURCHASENO = int.Parse(reader["PURCHASENO"].ToString()),
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    PURCHASEPRICE = int.Parse(reader["PURCHASEPRICE"].ToString()),
                                    PURCHASEDATE = DateTime.Parse(reader["PURCHASEDATE"].ToString())
                                };
                                purchases.Add(purchase);
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

            return purchases;
        }

        public static List<PURCHASES> GetPurchase(int id)
        {
            PURCHASES purchase = null;
            List<PURCHASES> purchases = new List<PURCHASES>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PURCHASES WHERE SELLERID=:sellerid";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":sellerid", id));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                purchase = new PURCHASES()
                                {
                                    PURCHASENO = int.Parse(reader["PURCHASENO"].ToString()),
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    PURCHASEPRICE = int.Parse(reader["PURCHASEPRICE"].ToString()),
                                    PURCHASEDATE = DateTime.Parse(reader["PURCHASEDATE"].ToString())
                                };
                                purchases.Add(purchase);
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

            return purchases;
        }

        public static bool InsertPurchase(PURCHASES detail)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO PURCHASES (SELLERID,PURCHASEDATE,PURCHASEPRICE) " +
                        "VALUES (:email,:password,:fname)";

                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":email", detail.SELLERID));
                    cmd.Parameters.Add(new OracleParameter(":password", detail.PURCHASEDATE));
                    cmd.Parameters.Add(new OracleParameter(":fname", detail.PURCHASEPRICE));

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
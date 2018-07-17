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
    public class PURCHASEDETAILSDAL
    {
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;

        public static List<PURCHASEDETAILS> GetAll()
        {
            PURCHASEDETAILS detail = null;
            List<PURCHASEDETAILS> details = new List<PURCHASEDETAILS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PURCHASEDETAILS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                detail = new PURCHASEDETAILS()
                                {
                                    DETAILNO = int.Parse(reader["DETAILNO"].ToString()),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                    PURCHASENO = int.Parse(reader["PURCHASENO"].ToString()),
                                    PRODUCTPRICE = int.Parse(reader["PRODUCTPRICE"].ToString()),
                                    QUANTITY = int.Parse(reader["QUANTITY"].ToString()),
                                };
                                details.Add(detail);
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

            return details;
        }

        public static List<PURCHASEDETAILS> GetAll(int purchaseNum)
        {
            PURCHASEDETAILS orderdetail = null;
            List<PURCHASEDETAILS> orderdetails = new List<PURCHASEDETAILS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM PURCHASEDETAILS WHERE PURCHASENO = " + purchaseNum;
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                orderdetail = new PURCHASEDETAILS()
                                {
                                    PURCHASENO = int.Parse(reader["PURCHASENO"].ToString()),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                    DETAILNO = int.Parse(reader["DETAILNO"].ToString()),
                                    PRODUCTPRICE = int.Parse(reader["PRODUCTPRICE"].ToString()),
                                    QUANTITY = int.Parse(reader["QUANTITY"].ToString())
                                };
                                orderdetails.Add(orderdetail);
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

            return orderdetails;
        }

        public static bool InsertPurchaseDetails(PURCHASEDETAILS detail)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO PURCHASEDETAILS (PURCHASENO,PRODUCTNO,QUANTITY,PRODUCTPRICE) " +
                        "VALUES (:email,:password,:fname,:lname)";

                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":email", detail.PURCHASENO));
                    cmd.Parameters.Add(new OracleParameter(":password", detail.PRODUCTNO));
                    cmd.Parameters.Add(new OracleParameter(":fname", detail.QUANTITY));
                    cmd.Parameters.Add(new OracleParameter(":lname", detail.PRODUCTPRICE));

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
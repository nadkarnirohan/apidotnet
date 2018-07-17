using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

using BOL;

namespace MarketDAL
{
    public class ORDERDETAILSDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;
        public static List<ORDERDETAILS> GetAll()
        {
            ORDERDETAILS orderdetail = null;
            List<ORDERDETAILS> orderdetails = new List<ORDERDETAILS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM ORDERDETAILS ";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                orderdetail = new ORDERDETAILS()
                                {
                                    ORDERNUM = int.Parse(reader["ORDERNUM"].ToString()),
                                    DETAILNO = int.Parse(reader["DETAILNO"].ToString()),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                    PRODUCTTOTAL = int.Parse(reader["PRODUCTTOTAL"].ToString()),
                                    QUANTITY = int.Parse(reader["QUANTITY"].ToString()),

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

        public static List<ORDERDETAILS> Get(int orderNum)
        {
            ORDERDETAILS orderdetail = null;
            List<ORDERDETAILS> orderdetails = new List<ORDERDETAILS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM ORDERDETAILS WHERE ORDERNUM = "+ orderNum;
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                orderdetail = new ORDERDETAILS()
                                {
                                    ORDERNUM = int.Parse(reader["ORDERNUM"].ToString()),
                                    DETAILNO = int.Parse(reader["DETAILNO"].ToString()),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                    PRODUCTTOTAL = int.Parse(reader["PRODUCTTOTAL"].ToString()),
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

        public static bool InsertOrderDetails(ORDERDETAILS detail)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO ORDERDETAILS (ORDERNUM,PRODUCTNO,QUANTITY,PRODUCTTOTAL) " +
                        "VALUES (:email,:password,:fname,:lname)";


                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":email", detail.ORDERNUM));
                    cmd.Parameters.Add(new OracleParameter(":password", detail.PRODUCTNO));
                    cmd.Parameters.Add(new OracleParameter(":fname", detail.QUANTITY));
                    cmd.Parameters.Add(new OracleParameter(":lname", detail.PRODUCTTOTAL));

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

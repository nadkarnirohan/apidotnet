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
   public class ORDERSDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;
        public static List<ORDERS> GetAll()
        {
            ORDERS order = null;
            List<ORDERS> orders = new List<ORDERS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM ORDERS ";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                order = new ORDERS()
                                {                                    
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    ORDERNUM = int.Parse(reader["ORDERNUM"].ToString()),
                                    ORDERTOTAL = int.Parse(reader["ORDERTOTAL"].ToString()),
                                    OREDERDATE=DateTime.Parse(reader["OREDERDATE"].ToString()),
                                    DELIVERYDATE = DateTime.Parse(reader["DELIVERYDATE"].ToString())
                                    
                                };
                                orders.Add(order);
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

            return orders;
        }

        public static List<ORDERS> GetOrders( int CustID)
        {
            ORDERS order = null;
            List<ORDERS> orders = new List<ORDERS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM ORDERS WHERE CUSTID ="+CustID;
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                order = new ORDERS()
                                {
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    ORDERNUM = int.Parse(reader["ORDERNUM"].ToString()),
                                    ORDERTOTAL = int.Parse(reader["ORDERTOTAL"].ToString()),
                                    OREDERDATE = DateTime.Parse(reader["OREDERDATE"].ToString()),
                                    DELIVERYDATE = DateTime.Parse(reader["DELIVERYDATE"].ToString())

                                };
                                orders.Add(order);
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

            return orders;
        }

        public static bool InsertOrder(ORDERS detail)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO ORDERS (CUSTID,OREDERDATE,DELIVERYDATE,ORDERTOTAL) " +
                        "VALUES (:email,:password,:fname,:lname)";


                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":email", detail.CUSTID));
                    cmd.Parameters.Add(new OracleParameter(":password", detail.OREDERDATE));
                    cmd.Parameters.Add(new OracleParameter(":fname", detail.DELIVERYDATE));
                    cmd.Parameters.Add(new OracleParameter(":lname", detail.ORDERTOTAL));

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

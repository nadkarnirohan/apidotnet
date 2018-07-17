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
    public class SELLERSADDRESSDAL
    {
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;

        public static List<SELLERSADDRESS> GetAll()
        {
            SELLERSADDRESS address = null;
            List<SELLERSADDRESS> addresses = new List<SELLERSADDRESS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERSADDRESS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address = new SELLERSADDRESS()
                                {
                                    ADDRESSID = int.Parse(reader["ADDRESSID"].ToString()),
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    STREET = reader["STREET"].ToString(),
                                    CITY = reader["CITY"].ToString(),
                                    DISTRICT = reader["DISTRICT"].ToString(),
                                    STATE = reader["STATE"].ToString(),
                                    PINCODE = int.Parse(reader["PINCODE"].ToString()),
                                };
                                addresses.Add(address);
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

            return addresses;
        }

        public static List<SELLERSADDRESS> GetAll(int sellerId)
        {
            SELLERSADDRESS address = null;
            List<SELLERSADDRESS> addresses = new List<SELLERSADDRESS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERSADDRESS WHERE SELLERID=:sellerId";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":sellerId", sellerId));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address = new SELLERSADDRESS()
                                {
                                    ADDRESSID = int.Parse(reader["ADDRESSID"].ToString()),
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    STREET = reader["STREET"].ToString(),
                                    CITY = reader["CITY"].ToString(),
                                    DISTRICT = reader["DISTRICT"].ToString(),
                                    STATE = reader["STATE"].ToString(),
                                    PINCODE = int.Parse(reader["PINCODE"].ToString()),
                                };
                                addresses.Add(address);
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

            return addresses;
        }

        public static bool InsertCustomerAddress(SELLERSADDRESS address)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO SELLERSADDRESS (SELLERID,STREET,CITY,DISTRICT,STATE,PINCODE) " +
                        "VALUES (:sellerId,:street,:city,:district,:state,:pincode)";

                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":sellerId", address.SELLERID));
                    cmd.Parameters.Add(new OracleParameter(":street", address.STREET));
                    cmd.Parameters.Add(new OracleParameter(":city", address.CITY));
                    cmd.Parameters.Add(new OracleParameter(":district", address.DISTRICT));
                    cmd.Parameters.Add(new OracleParameter(":state", address.STATE));
                    cmd.Parameters.Add(new OracleParameter(":pincode", address.PINCODE));

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

        public static bool UpdateCustomerAddress(SELLERSADDRESS address)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE SELLERSADDRESS SET STREET= :street ,CITY = :city,DISTRICT= :district,STATE=:state,PINCODE=:pincode where ADDRESSID=:addid";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":addid", address.ADDRESSID));
                    cmd.Parameters.Add(new OracleParameter(":street", address.STREET));
                    cmd.Parameters.Add(new OracleParameter(":city", address.CITY));
                    cmd.Parameters.Add(new OracleParameter(":district", address.DISTRICT));
                    cmd.Parameters.Add(new OracleParameter(":state", address.STATE));
                    cmd.Parameters.Add(new OracleParameter(":pincode", address.PINCODE));

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

        public static bool DeleteAddress(int addressID)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "DELETE FROM SELLERSADDRESS WHERE ADDRESSID = :addressid";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":addressid", addressID));

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
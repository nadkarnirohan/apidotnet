using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;

using BOL;

namespace MarketDAL
{
    public class CUSTOMERADDRESSDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;
        public static List<CUSTOMERADDRESS> GetAll()
        {
            CUSTOMERADDRESS address = null;
            List<CUSTOMERADDRESS> addresses = new List<CUSTOMERADDRESS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM CUSTOMERADDRESS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address = new CUSTOMERADDRESS()
                                {
                                    ADDRESSID = int.Parse(reader["ADDRESSID"].ToString()),
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    STREET = reader["STREET"].ToString(),
                                    CITY = reader["CITY"].ToString(),
                                    DISTRICT = reader["DISTRICT"].ToString(),
                                    STATE= reader["STATE"].ToString(),
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

        public static List<CUSTOMERADDRESS> GetAddress(int customerId)
        {
            CUSTOMERADDRESS address = null;
            List<CUSTOMERADDRESS> addresses = new List<CUSTOMERADDRESS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM CUSTOMERADDRESS WHERE CUSTID="+ customerId;
                    OracleCommand cmd = new OracleCommand(query, con);
                    //cmd.Parameters.Add(new OracleParameter(":customerId", customerId));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                address = new CUSTOMERADDRESS()
                                {
                                    ADDRESSID = int.Parse(reader["ADDRESSID"].ToString()),
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
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

        public static bool InsertCustomerAddress(CUSTOMERADDRESS address)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO CUSTOMERADDRESS (CUSTID,STREET,CITY,DISTRICT,STATE,PINCODE) " +
                        "VALUES (:custid,:street,:city,:district,:state,:pincode)";
            
                     
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":custid", address.CUSTID));
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

        public static bool UpdateCustomerAddress(CUSTOMERADDRESS address)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE CUSTOMERADDRESS SET STREET= :street ,CITY = :city,DISTRICT= :district,STATE=:state,PINCODE=:pincode where ADDRESSID=:addid";
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
                    string query = "DELETE FROM CUSTOMERADDRESS WHERE ADDRESSID = :addressid";
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

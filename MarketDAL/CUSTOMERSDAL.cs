using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

using BOL;

namespace MarketDAL
{
   public class CUSTOMERSDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;


        public static CUSTOMERS Get(int customerId)
        {
            CUSTOMERS customer = null;
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM CUSTOMERS WHERE CUSTID=" + customerId;
                    OracleCommand cmd = new OracleCommand(query, con);
                   // cmd.Parameters.Add(new OracleParameter(":customerId", customerId));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                customer = new CUSTOMERS()
                                {
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"].ToString(),
                                    PHONE = long.Parse(reader["PHONE"].ToString()),
                                    
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
            return customer;
        }

        public static CUSTOMERS Get(string customerEmail)
        {
            CUSTOMERS customer = null;
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM CUSTOMERS WHERE EMAIL =:customerEmail";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":customerEmail", customerEmail));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                customer = new CUSTOMERS()
                                {
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"].ToString(),
                                    PHONE = long.Parse(reader["PHONE"].ToString()),

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
            return customer;
        }

        public static List<CUSTOMERS> GetAll()
        {
            CUSTOMERS customer = null;
            List<CUSTOMERS> customers = new List<CUSTOMERS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM CUSTOMERS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                customer = new CUSTOMERS()
                                {
                                    CUSTID = int.Parse(reader["CUSTID"].ToString()),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"].ToString(),
                                    PHONE = long.Parse(reader["PHONE"].ToString()),
                                };
                                customers.Add(customer);
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

            return customers;
        }


        public static bool InsertCustomer(CUSTOMERS customer)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    string query = "INSERT INTO CUSTOMERS (EMAIL,PASSWORD,FIRSTNAME,LASTNAME,PHONE) " +
                        "VALUES (:email,:password,:fname,:lname,:phone)";


#pragma warning disable CS0618 // Type or member is obsolete
                    OracleCommand cmd = new OracleCommand(query, connection);
#pragma warning restore CS0618 // Type or member is obsolete
                    cmd.Parameters.Add(new OracleParameter(":email", customer.EMAIL));
                    cmd.Parameters.Add(new OracleParameter(":password", customer.PASSWORD));
                    cmd.Parameters.Add(new OracleParameter(":fname", customer.FIRSTNAME));
                    cmd.Parameters.Add(new OracleParameter(":lname", customer.LASTNAME));
                    cmd.Parameters.Add(new OracleParameter(":phone", customer.PHONE));

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

        public static bool UpdateCustomer(CUSTOMERS customer)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE CUSTOMERS SET EMAIL= :email ,FIRSTNAME= :fname,LASTNAME=:lname,PHONE=:phone where CUSTID = :custid";
                    OracleCommand cmd = new OracleCommand(query, connection);
                   
                    cmd.Parameters.Add(new OracleParameter(":custid", customer.CUSTID));
                    cmd.Parameters.Add(new OracleParameter(":email", customer.EMAIL));
                    cmd.Parameters.Add(new OracleParameter(":fname", customer.FIRSTNAME));
                    cmd.Parameters.Add(new OracleParameter(":lname", customer.LASTNAME));
                    cmd.Parameters.Add(new OracleParameter(":phone", customer.PHONE));

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


        public static bool DeleteCustomer(int id)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "DELETE FROM CUSTOMERS WHERE CUSTID = :id";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":id", id));

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

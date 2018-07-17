using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace MarketDAL
{
    public class SELLERSDAL
    {
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;

        public static List<SELLERS> GetAll()
        {
            SELLERS seller = null;
            List<SELLERS> sellers = new List<SELLERS>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERS";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                seller = new SELLERS()
                                {
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    SELLERNAME = reader["SELLERNAME"].ToString(),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"].ToString(),
                                    PASSWORD = reader["PASSWORD"].ToString(),
                                    PHONE = long.Parse(reader["PHONE"].ToString())
                                };
                                sellers.Add(seller);
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

            return sellers;
        }

        public static SELLERS Get(int sellerId)
        {
            SELLERS customer = null;
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERS WHERE SELLERID=:sellerId";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":sellerId", sellerId));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                customer = new SELLERS()
                                {
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    SELLERNAME = reader["SELLERNAME"].ToString(),
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

        public static SELLERS Get(string sellerEmail)
        {
            SELLERS customer = null;
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERS WHERE EMAIL =:selleremail";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(new OracleParameter(":selleremail", sellerEmail));
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                customer = new SELLERS()
                                {
                                    SELLERID = int.Parse(reader["SELLERID"].ToString()),
                                    SELLERNAME = reader["SELLERNAME"].ToString(),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"].ToString(),
                                    PASSWORD = reader["PASSWORD"].ToString(),
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

        public static bool InsertSeller(SELLERS seller)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO SELLERS (SELLERNAME,EMAIL,PASSWORD,FIRSTNAME,LASTNAME,PHONE) " +
                        "VALUES (:sellername,:email,:password,:fname,:lname,:phone)";

                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":sellername", seller.SELLERNAME));
                    cmd.Parameters.Add(new OracleParameter(":email", seller.EMAIL));
                    cmd.Parameters.Add(new OracleParameter(":password", seller.PASSWORD));
                    cmd.Parameters.Add(new OracleParameter(":fname", seller.FIRSTNAME));
                    cmd.Parameters.Add(new OracleParameter(":lname", seller.LASTNAME));
                    cmd.Parameters.Add(new OracleParameter(":phone", seller.PHONE));

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

        public static bool UpdateSeller(SELLERS seller)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE SELLERS SET SELLERNAME= :sellername , EMAIL= :email ,FIRSTNAME= :fname,LASTNAME=:lname,PHONE=:phone where SELLERID = :sellerid";
                    OracleCommand cmd = new OracleCommand(query, connection);

                    cmd.Parameters.Add(new OracleParameter(":sellerid", seller.SELLERID));
                    cmd.Parameters.Add(new OracleParameter(":sellername", seller.SELLERNAME));
                    cmd.Parameters.Add(new OracleParameter(":email", seller.EMAIL));
                    cmd.Parameters.Add(new OracleParameter(":fname", seller.FIRSTNAME));
                    cmd.Parameters.Add(new OracleParameter(":lname", seller.LASTNAME));
                    cmd.Parameters.Add(new OracleParameter(":phone", seller.PHONE));

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

        public static bool DeleteSeller(int id)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "DELETE FROM SELLERS WHERE SELLERID = :id";
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
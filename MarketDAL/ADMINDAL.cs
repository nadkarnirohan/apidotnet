using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;
namespace MarketDAL
{
    public class ADMINDAL
    {
        private List<ADMIN> adminList = new List<ADMIN>();
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static ADMIN GetAdmin(int id)
        {
            ADMIN admin = null;
            string query = "select * from ADMIN where ADMINID =:id";
            OracleConnection connection = new OracleConnection(conlink);
            OracleCommand command = new OracleCommand(query, connection);
            command.Parameters.Add(new OracleParameter(":id", id));

            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        admin = new ADMIN()
                        {
                            ADMINID = int.Parse(reader["ADMINID"].ToString()),
                            ADMINNAME = reader["ADMINNAME"].ToString(),
                            PASSWORD = reader["PASSWORD"].ToString(),
                        };
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }
            return admin;
        }

        public static List<ADMIN> GetAdmins()
        {
            List<ADMIN> adminList = new List<ADMIN>();
            ADMIN admin = null;
            string query = "select * from ADMIN";
            OracleConnection connection = new OracleConnection(conlink);
            OracleCommand command = new OracleCommand(query, connection);

            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        admin = new ADMIN()
                        {
                            ADMINID = int.Parse(reader["ADMINID"].ToString()),
                            ADMINNAME = reader["ADMINNAME"].ToString(),
                            PASSWORD = reader["PASSWORD"].ToString(),
                        };

                        adminList.Add(admin);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { connection.Close(); }

            return adminList;
        }

        public static bool InsertAdmin(ADMIN admin)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO ADMIN (ADMINNAME,PASSWORD) " +
                        "VALUES (:adminname,:password)";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":adminname", admin.ADMINNAME));
                    cmd.Parameters.Add(new OracleParameter(":password", admin.PASSWORD));

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

        public static bool UpdateAdmin(ADMIN admin)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "UPDATE ADMIN SET ADMINNAME= :adminname ,PASSWORD = :password  where ADMINID=:adminid";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":adminname", admin.ADMINNAME));
                    cmd.Parameters.Add(new OracleParameter(":password", admin.PASSWORD));
                    cmd.Parameters.Add(new OracleParameter(":adminid", admin.ADMINID));

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

        public static bool DeleteAdmin(int adminId)
        {
            bool status = false;
            try
            {
                using (OracleConnection connection = new OracleConnection(conlink))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "DELETE FROM ADMIN WHERE ADMINID = :adminid";
                    OracleCommand cmd = new OracleCommand(query, connection);
                    cmd.Parameters.Add(new OracleParameter(":adminid", adminId));

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
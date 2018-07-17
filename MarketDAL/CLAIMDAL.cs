using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
//using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using BOL;
namespace MarketDAL
{
    public class CLAIMDAL
    {

        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;


        public static CLAIM GetClaim(string email)
        {
            CLAIM claim = new CLAIM();
            string query = "select * from CLAIM where EMAIL = :email";
            OracleConnection connection = new OracleConnection(conlink);
            OracleCommand command = new OracleCommand(query, connection);
            command.Parameters.Add(new OracleParameter(":email", email));


            try
            {
                connection.Open();
                OracleDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        claim.EMAIL = reader["EMAIL"].ToString();
                        claim.PASSWORD = reader["PASSWORD"].ToString();
                        claim.CUSTID = int.Parse(reader["CUSTID"].ToString());

                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
               throw ex;

            }
            finally { connection.Close(); }
            return claim;
        }


    }
}

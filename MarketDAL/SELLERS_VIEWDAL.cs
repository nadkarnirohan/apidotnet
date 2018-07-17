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
    public  class SELLERS_VIEWDAL
    {
        static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;
        public static List<SELLERS_VIEW> GetAll()
        {
            SELLERS_VIEW seller = null;
            List<SELLERS_VIEW> sellers = new List<SELLERS_VIEW>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM SELLERS_VIEW";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                seller = new SELLERS_VIEW()
                                {
                                    SELLERNAME  = reader["SELLERNAME"].ToString(),
                                    EMAIL = reader["EMAIL"].ToString(),
                                    PASSWORD = reader["PASSWORD"].ToString()

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

    }
}

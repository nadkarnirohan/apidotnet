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
    public class INVENTORYDAL
    {
        private static readonly string conlink = ConfigurationManager.ConnectionStrings["MarketDB"].ConnectionString;

        public static string Conlink => conlink;

        public static List<INVENTORY> GetAll()
        {
            INVENTORY item = null;
            List<INVENTORY> items = new List<INVENTORY>();
            try
            {
                using (OracleConnection con = new OracleConnection(conlink))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM INVENTORY ";
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                item = new INVENTORY()
                                {
                                    PRODUCTNAME = reader["PRODUCTNAME"].ToString(),
                                    QUANTITY = int.Parse(reader["QUANTITY"].ToString()),
                                    PRODUCTNO = int.Parse(reader["PRODUCTNO"].ToString()),
                                };
                                items.Add(item);
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

            return items;
        }
    }
}
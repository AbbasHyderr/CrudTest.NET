using System;
using System.Data;
using System.Data.SqlClient;

namespace TestCrud.Factory
{
    public class Logs : ILog
    {
       

        public int Id { get ; set ; }
        public string? queryString { get; set; }
        public DateTime executedOn { get; set; }

        public  int AddLogs(string queryString, string connString)
        {
            var newProdID = 0;
            const string sql =
                "INSERT INTO SqlLogs (queryString,executedOn) VALUES (@queryString,@executedOn); "
                + "SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new(connString))
            {
                SqlCommand cmd = new(sql, conn);


                cmd.Parameters.Add("@queryString", SqlDbType.VarChar);
                cmd.Parameters["@queryString"].Value = queryString;

                cmd.Parameters.Add("@executedOn", SqlDbType.DateTime);
                cmd.Parameters["@executedOn"].Value = DateTime.Now;
                try
                {
                    conn.Open();
                    newProdID = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newProdID;


        }
    }
    
}

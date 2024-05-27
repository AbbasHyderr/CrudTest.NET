using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;


namespace TestCrud.SqlCommandDynamicCrud
{
    internal class dynamicCrud
    {
        public static int AddRecord(string newName, string Gender, string Email, string connString)
        {
            var newProdID = 0;
            const string sql =
                "INSERT INTO Record (Name,Gender,Email) VALUES (@Name,@Gender,@Email); "
                + "SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new(connString))
            {
                SqlCommand cmd = new(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@name"].Value = newName;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = Email;

                cmd.Parameters.Add("@Gender", SqlDbType.VarChar);
                cmd.Parameters["@gender"].Value = Gender;
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
        public static int UpdateRecord(string id, string Email, string connString)
        {
            var affectedRows = 0;
            const string sql =
                "UPDATE Record " +
                "SET Email = @Email " +
                "WHERE id = @Id;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                try
                {
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return affectedRows;
        }
        public static int DeleteRecord(string id, string connString)
        {
            var affectedRows = 0;
            const string sql =
                "Delete Record " +
                "WHERE id = @Id;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                try
                {
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return affectedRows;
        }
        public static void ReadRecords(
    string connectionString)
        {
            string queryString = "Select * From Record";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("id: " + reader.GetValue(0).ToString());
                        Console.WriteLine("Name: " + reader.GetValue(1).ToString());
                        Console.WriteLine("Gender: " + reader.GetValue(2).ToString());
                        Console.WriteLine("Email: " + reader.GetValue(3).ToString());
                    }
                }
            }
        }

    }
}



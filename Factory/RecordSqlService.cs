using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestCrud.Factory
{
    public class RecordSqlService() : IFactory
    {
        private readonly ILog _log;
        public RecordSqlService(ILog log) : this()
        {
            _log = log;
        }



        SqlConnection sqlConnection;
        string connectionString = @"Data Source=Hp\SQLEXPRESS;Initial Catalog=StudentRecord;Integrated Security=True;";

        public void DeleteRecord()

        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            int d_id;
            Console.WriteLine("Enter the id of record to be deleted");
            d_id = int.Parse(Console.ReadLine());
            string deleteQuerry = "DELETE FROM RECORD WHERE id = " + d_id;

            _log?.AddLogs(deleteQuerry, connectionString);

            SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
            deleteCommand.ExecuteNonQuery();

            Console.WriteLine("Deleted Successfully");
            sqlConnection.Close();
        }

        public string GetMethod()
        {
            return "Sql";
        }

        public void InsertTable( )
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your Gender");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();

            string insertQuerry = "INSERT INTO RECORD(Name,Gender, Email) " +
                "VALUES('" + name + "', '" + gender + "', '" + email + "') ";

            _log?.AddLogs(insertQuerry, connectionString);

            SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);

            insertCommand.ExecuteNonQuery();

            Console.WriteLine("Data Sucessfully inserted");
        }

        public void ReadTable()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string displayQuerry = "SELECT * FROM RECORD";

            _log?.AddLogs(displayQuerry, connectionString);

            SqlCommand displayCommand = new SqlCommand(displayQuerry, sqlConnection);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("id: " + dataReader.GetValue(0).ToString());
                Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                Console.WriteLine("Gender: " + dataReader.GetValue(2).ToString());
                Console.WriteLine("Email: " + dataReader.GetValue(3).ToString());
            }
            dataReader.Close();
        }

        public void UpdateTable()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string u_email;
            int u_id;
            Console.WriteLine("Enter id of user you want to update");
            u_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter email of user to update");
            u_email = Console.ReadLine();
            string updateQuerry = "UPDATE RECORD SET Email = '" + u_email + "' WHERE id = " + u_id;
            _log?.AddLogs(updateQuerry, connectionString);

            SqlCommand updateCommand = new SqlCommand(updateQuerry, sqlConnection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Data Updated");
        }
    }
}

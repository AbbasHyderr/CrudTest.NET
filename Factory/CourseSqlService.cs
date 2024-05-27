using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestCrud.Factory
{
    public class CourseSqlService() : IFactory

    {
        private readonly ILog _log;

        public CourseSqlService(ILog log) : this()
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
            Console.WriteLine("Enter the id of course to be deleted");
            d_id = int.Parse(Console.ReadLine());
            string deleteQuerry = "DELETE FROM Courses WHERE id = " + d_id;
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

        public void InsertTable()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Enter Course Name");
            string CourseName = Console.ReadLine();

            Console.WriteLine("Enter Course ID");
            string Course_Id = Console.ReadLine();

            

            string insertQuerry = "INSERT INTO Courses(CourseName, CourseId) " +
                "VALUES('" + CourseName + "', '" + Course_Id + "') ";
            _log?.AddLogs(insertQuerry, connectionString);

            SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);

            insertCommand.ExecuteNonQuery();

            Console.WriteLine("Data Sucessfully inserted");
        }

        public void ReadTable()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string displayQuerry = "SELECT * FROM Courses";
            _log?.AddLogs(displayQuerry, connectionString);

            SqlCommand displayCommand = new SqlCommand(displayQuerry, sqlConnection);
            SqlDataReader dataReader = displayCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("id: " + dataReader.GetValue(0).ToString());
                Console.WriteLine("CourseName: " + dataReader.GetValue(1).ToString());
                Console.WriteLine("CourseId: " + dataReader.GetValue(2).ToString());
               
            }
            dataReader.Close();
        }

        public void UpdateTable()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string course_id;
            int c_id;
            Console.WriteLine("Enter id of course you want to update");
            c_id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter email of user to update");
            course_id = Console.ReadLine();
            string updateQuerry = "UPDATE Courses SET Course_Id = '" + course_id + "' WHERE id = " + c_id;

            _log?.AddLogs(updateQuerry, connectionString);

            SqlCommand updateCommand = new SqlCommand(updateQuerry, sqlConnection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Data Updated");
        }
    }
}

// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
class Crud
{
    public void CRUD()
    {

        SqlConnection sqlConnection;
        string connectionString = @"Data Source=Hp\SQLEXPRESS;Initial Catalog=StudentRecord;Integrated Security=True;";

        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection to db Successfull");


            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tc - Create");
            Console.WriteLine("\tr - Read");
            Console.WriteLine("\tu - Update");
            Console.WriteLine("\td - Delete");
            Console.Write("Your option? ");




            switch (Console.ReadLine())
            {

                case "c":
                    Console.WriteLine("Enter your Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter your Gender");
                    string gender = Console.ReadLine();

                    Console.WriteLine("Enter your email");
                    string email = Console.ReadLine();

                    string insertQuerry = "INSERT INTO RECORD(Name,Gender, Email) " +
                        "VALUES('" + name + "', '" + gender + "', '" + email + "') ";
                    SqlCommand insertCommand = new SqlCommand(insertQuerry, sqlConnection);

                    insertCommand.ExecuteNonQuery();

                    Console.WriteLine("Data Sucessfully inserted");
                    break;

                case "r":
                    string displayQuerry = "SELECT * FROM RECORD";
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
                    break;

                case "u":
                    string u_email;
                    int u_id;
                    Console.WriteLine("Enter id of user you want to update");
                    u_id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter email of user to update");
                    u_email = Console.ReadLine();
                    //string updateQuerry = "UPDATE RECORD SET Email = " + u_email + " " + " Where id = " + u_id + "";
                    string updateQuerry = "UPDATE RECORD SET Email = '" + u_email + "' WHERE id = " + u_id;

                    SqlCommand updateCommand = new SqlCommand(updateQuerry, sqlConnection);
                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Data Updated");
                    break;

                case "d":
                    int d_id;
                    Console.WriteLine("Enter the id of record to be deleted");
                    d_id = int.Parse(Console.ReadLine());
                    string deleteQuerry = "DELETE FROM RECORD WHERE id = " + d_id;
                    SqlCommand deleteCommand = new SqlCommand(deleteQuerry, sqlConnection);
                    deleteCommand.ExecuteNonQuery();

                    Console.WriteLine("Deleted Successfully");
                    break;


            }
            sqlConnection.Close();




        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }


    }
}

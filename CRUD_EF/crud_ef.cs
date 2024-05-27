using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCrud.Factory;

namespace TestCrud.CRUD_EF
{
    //IFactory method2 = FactoryController.GetMethod("CourseSql");
    //Console.WriteLine("Initaiting SQL");
    class CRUD_ef
    {
        public void crud_ef()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tc - Create");
            Console.WriteLine("\tr - Read");
            Console.WriteLine("\tu - Update");
            Console.WriteLine("\td - Delete");
            Console.Write("Your option? ");
            try
            {

                switch (Console.ReadLine())
                {
                    case "c":
                        using (var db = new StudentRecordContext())
                        {
                            Record record = new Record();
                            Console.WriteLine("Enter Name: ");
                            record.Name = Console.ReadLine();

                            Console.WriteLine("Enter Gender: ");
                            record.Gender = Console.ReadLine();

                            Console.WriteLine("Enter Email: ");
                            record.Email = Console.ReadLine();

                            db.Add(record);
                            db.SaveChanges();
                            Console.WriteLine("Record Sucessfully inserted");




                        }
                        break;

                    case "r":
                        using (var db = new StudentRecordContext())
                        {
                            List<Record> records = db.Records.ToList();
                            foreach (Record record in records)
                            {
                                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                                    record.Id, " ", record.Name, " ", record.Gender, " ", record.Email);

                            }
                        }
                        break;

                    case "u":
                        using (var db = new StudentRecordContext())
                        {
                            Console.WriteLine("Enter the Id of user you want to update: ");

                            Record record = db.Records.Find(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter the updated Email:");
                            record.Email = Console.ReadLine();
                            db.SaveChanges();
                            Console.WriteLine("Record Sucessfully updated");

                        }
                        break;

                    case "d":
                        using (var db = new StudentRecordContext())
                        {
                            Console.WriteLine("Enter the Id of user you want to delete: ");
                            Record record = db.Records.Find(int.Parse(Console.ReadLine()));
                            db.Records.Remove(record);
                            db.SaveChanges();
                            Console.WriteLine("Record Sucessfully deletred");

                        }
                        break;
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }



            
        }
    }
}

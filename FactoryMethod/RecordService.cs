using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using TestCrud.CRUD_EF;



namespace TestCrud.FactoryMethod
{
    internal class RecordService : ISuperClass
    {
        public void DeleteRecord()
        {
            using (var db = new StudentRecordContext())
            {
                Console.WriteLine("Enter the Id of user you want to delete: ");
                Record record = db.Records.Find(int.Parse(Console.ReadLine()));
                db.Records.Remove(record);
                db.SaveChanges();
                Console.WriteLine("Record Sucessfully deletred");

            }
        }

        public string GetTableName()
        {
            return "Record";
        }

        public void InsertTable()
        {
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
        }

        public void ReadTable()
        {
            using (var db = new StudentRecordContext())
            {
                List<Record> records = db.Records.ToList();
                foreach (Record record in records)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}",
                        record.Id, " ", record.Name, " ", record.Gender, " ", record.Email);

                }
            }
        }

        public void UpdateTable()
        {
            using (var db = new StudentRecordContext())
            {
                Console.WriteLine("Enter the Id of user you want to update: ");

                Record record = db.Records.Find(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the updated Email:");
                record.Email = Console.ReadLine();
                db.SaveChanges();
                Console.WriteLine("Record Sucessfully updated");

            }
        }
    }
}




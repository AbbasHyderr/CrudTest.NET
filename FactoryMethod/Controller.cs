using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud.FactoryMethod
{
    public class Controller 
    {
        public static ISuperClass GetTableName(string  tableName)
        {
            ISuperClass table = null;
            if (tableName== "Record")
            {
                table = new RecordService();
            }
            return table;
        }
    }
}

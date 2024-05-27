using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCrud.FactoryMethod;

namespace TestCrud.Factory
{
    public class FactoryController
    {
        public static IFactory GetMethod(string methodName)
        {
            IFactory method = null;
            if (methodName == "Orm")
            {
                method = new OrmService();
            }
            if (methodName == "RecordSql")
            {
                method = new RecordSqlService();
            }

            else if (methodName == "CourseSql")
            {
                method = new CourseSqlService();
            }
            return method;
        }
    }
}

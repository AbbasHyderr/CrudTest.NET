using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud.FactoryMethod
{
    public interface ISuperClass
    {
        string GetTableName();
        void InsertTable();
        void UpdateTable();
        void ReadTable();
        void DeleteRecord();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud.Factory
{
    public interface IFactory
    {
        string GetMethod();
        void InsertTable();
        void UpdateTable();
        void ReadTable();
        void DeleteRecord();


    }
}

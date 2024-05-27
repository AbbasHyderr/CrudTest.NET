using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrud.Factory
{
    public interface ILog
    {
        public int Id { get; set; }
        public string? queryString { get; set; }
        public DateTime executedOn { get; set; }

        public  int AddLogs(string queryString, string connString);

    }
}

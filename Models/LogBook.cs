using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class LogBook
    {
        private List<Log> _logBook;
        public LogBook()
        {
            _logBook = new List<Log>();
        }
        public void AddLog(Log log)
        {
            _logBook.Add(log);
        }
    }
}

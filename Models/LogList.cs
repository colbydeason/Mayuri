using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class LogList : ILogList
    {
        public LogList()
        {
        }

        public Task CreateLog(Log log)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Source>> GetAllSources()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Source>> GetCurrentSources()
        {
            throw new NotImplementedException();
        }
    }
}

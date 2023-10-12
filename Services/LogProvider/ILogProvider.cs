using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Services.LogProvider
{
    public interface ILogProvider
    {
        public Task<IEnumerable<Log>> GetAllLogs();
    }
}

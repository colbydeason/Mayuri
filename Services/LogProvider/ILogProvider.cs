using Mayuri.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mayuri.Services.LogProvider
{
    public interface ILogProvider
    {
        public Task<IEnumerable<Log>> GetAllLogs();
    }
}

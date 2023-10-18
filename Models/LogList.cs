using Mayuri.DBContexts;
using Mayuri.Services.LogCreators;
using Mayuri.Services.LogProvider;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public class LogList : ILogList
    {
        private readonly ILogCreator _logCreator;
        private readonly ILogProvider _logProvider;
        private const string CONNECTION = "Data Source=mayuri.db";
        private readonly MayuriDbContextFactory _mayuriDbContextFactory;
        public LogList()
        {
            _mayuriDbContextFactory = new MayuriDbContextFactory(CONNECTION);
            _logCreator = new DatabaseLogCreator(_mayuriDbContextFactory);
            _logProvider = new DatabaseLogProvider(_mayuriDbContextFactory);
        }

        public async Task CreateLog(Log log)
        {
            await _logCreator.CreateLog(log);
        }

        public async Task<IEnumerable<Log>> GetAllLogs()
        {
            return await _logProvider.GetAllLogs();
        }
    }
}

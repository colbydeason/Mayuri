using Mayuri.DbContexts;
using Mayuri.DBContexts;
using Mayuri.DTOs;
using Mayuri.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Services.LogProvider
{
    public class DatabaseLogProvider : ILogProvider
    {
        private readonly MayuriDbContextFactory _dbContextFactory;
        public DatabaseLogProvider(MayuriDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory; 
        }
        public async Task<IEnumerable<Log>> GetAllLogs()
        {
            using (MayuriDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<LogDTO> logDTOs = await context.Logs.ToListAsync();

                return logDTOs.Select(r => ToLog(r)); 
            }
        }
        private static Log ToLog(LogDTO r)
        {
            return new Log(r.Duration, r.SourceId); 
        }
    }
}

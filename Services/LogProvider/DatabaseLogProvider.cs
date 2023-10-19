using Mayuri.DbContexts;
using Mayuri.DBContexts;
using Mayuri.DTOs;
using Mayuri.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                IEnumerable<LogDTO> logDTOs = await context.Logs.Include(r => r.Source).ToListAsync();

                return logDTOs.Select(r => ToLog(r));
            }
        }
        private static Log ToLog(LogDTO r)
        {
            Source src = new Source(r.Source.Name, r.Source.Description, r.Source.Type,
                r.Source.OneTime, r.Source.Completed, r.Source.TotalDuration);
            return new Log(r.Duration, r.SourceId, r.LoggedAt, src);
        }
    }
}

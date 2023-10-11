using Mayuri.DbContexts;
using Mayuri.DBContexts;
using Mayuri.DTOs;
using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Services.LogCreators
{
    public class DatabaseLogCreator : ILogCreator
    {
        private readonly MayuriDbContextFactory _dbContextFactory;
        public DatabaseLogCreator(MayuriDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory; 
        }
        public async Task CreateLog(Log log)
        {
            using (MayuriDbContext context = _dbContextFactory.CreateDbContext())
            {
                LogDTO logDTO = ToLogDTO(log);

                context.Logs.Add(logDTO);
                await context.SaveChangesAsync();
            }
        }

        private LogDTO ToLogDTO(Log log)
        {
            return new LogDTO()
            {
                SourceId = log.SourceId,
                LoggedAt = log.LoggedAt,
                Duration = log.Duration,
            };
        }
    }
}

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

namespace Mayuri.Services.SourceProvider
{
    public class DatabaseSourceProvider : ISourceProvider
    {
        private readonly MayuriDbContextFactory _dbContextFactory;
        public DatabaseSourceProvider(MayuriDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory; 
        }
        public async Task<IEnumerable<Source>> GetAllSources()
        {
            using (MayuriDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SourceDTO> sourceDTOs = await context.Sources.ToListAsync();

                return sourceDTOs.Select(r => ToSource(r)); 
            }
        }
        private static Source ToSource(SourceDTO r)
        {
            return new Source(r.Name, r.Description, r.Type, r.OneTime, r.Completed, r.TotalDuration, r.SourceId);
        }
        public async Task<IEnumerable<Source>> GetCurrentSources()
        {
            using (MayuriDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SourceDTO> sourceDTOs = await context.Sources.Where(r => r.OneTime == false).ToListAsync();

                return sourceDTOs.Select(r => ToSource(r));
            }
        }
        public async Task<List<KeyValuePair<Guid, string>>> GetCurrentSourcesList()
        {
            List<KeyValuePair<Guid, string>> list = new List<KeyValuePair<Guid, string>>();
            foreach (var s in await GetCurrentSources())
            {
                list.Add(new KeyValuePair<Guid, string>(s.SourceId, s.Name));
            }
            return list;
        }
    }
}

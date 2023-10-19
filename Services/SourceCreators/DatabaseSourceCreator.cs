using Mayuri.DbContexts;
using Mayuri.DBContexts;
using Mayuri.DTOs;
using Mayuri.Models;
using System.Threading.Tasks;

namespace Mayuri.Services.SourceCreators
{
    public class DatabaseSourceCreator : ISourceCreator
    {
        private readonly MayuriDbContextFactory _dbContextFactory;
        public DatabaseSourceCreator(MayuriDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateSource(Source source)
        {
            using (MayuriDbContext context = _dbContextFactory.CreateDbContext())
            {
                SourceDTO sourceDTO = ToSourceDTO(source);

                context.Sources.Add(sourceDTO);
                await context.SaveChangesAsync();
            }
        }

        private SourceDTO ToSourceDTO(Source source)
        {
            return new SourceDTO()
            {
                Name = source.Name,
                Description = source.Description,
                Type = source.Type,
                OneTime = source.OneTime,
                Completed = source.Completed,
                TotalDuration = source.TotalDuration,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt,
            };
        }
    }
}

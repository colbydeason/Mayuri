using Mayuri.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mayuri.DBContexts
{
    public class MayuriDbContextFactory
    {
        private readonly string _connectionString;
        public MayuriDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MayuriDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new MayuriDbContext(options);
        }
    }
}

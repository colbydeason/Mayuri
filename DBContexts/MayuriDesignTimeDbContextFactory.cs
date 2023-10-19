using Mayuri.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Mayuri.DBContexts
{
    internal class MayuriDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MayuriDbContext>
    {
        public MayuriDbContext CreateDbContext(string[] args)
        {
            var dir = Assembly.GetEntryAssembly()!.Location;
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=mayuri.db").Options;
            return new MayuriDbContext(options);
        }
    }
}

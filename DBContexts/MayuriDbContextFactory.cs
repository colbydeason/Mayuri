using Mayuri.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("_connectionString").Options;
            return new MayuriDbContext(options);
        }
    }
}

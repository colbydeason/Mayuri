using Mayuri.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.DBContexts
{
    internal class MayuriDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MayuriDbContext>
    {
        public MayuriDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=mayuri.db").Options;
            return new MayuriDbContext(options);
        }
    }
}

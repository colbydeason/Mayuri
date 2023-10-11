using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mayuri.DTOs;
using Mayuri.Models;
using Microsoft.EntityFrameworkCore;

namespace Mayuri.DbContexts
{
    public class MayuriDbContext : DbContext
    {
        public MayuriDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        public DbSet<LogDTO> Logs { get; set; }
        public DbSet<SourceDTO> Sources { get; set; }
        
    }
}

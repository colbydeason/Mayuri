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

        public DbSet<LogDTO> Logs { get; set; }
        public DbSet<SourceDTO> Sources { get; set; }
        
    }
}

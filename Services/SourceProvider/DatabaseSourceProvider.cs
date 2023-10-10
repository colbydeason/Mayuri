﻿using Mayuri.DbContexts;
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
            return new Source(r.Name, r.Description, r.Type, r.OneTime, r.Completed, r.TotalDuration);
        }
    }
}
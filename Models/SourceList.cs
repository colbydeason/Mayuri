using Mayuri.Services.SourceCreators;
using Mayuri.Services.SourceProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mayuri.Models;
using Mayuri.DBContexts;

namespace Mayuri.Models
{
    public class SourceList : ISourceList
    {
        private readonly ISourceProvider _sourceProvider;
        private readonly ISourceCreator _sourceCreator;
        private const string CONNECTION = "Data Source=mayuri.db";
        private readonly MayuriDbContextFactory _mayuriDbContextFactory;
        public SourceList()
        {
            _mayuriDbContextFactory = new MayuriDbContextFactory(CONNECTION);
            _sourceProvider = new DatabaseSourceProvider(_mayuriDbContextFactory);
            _sourceCreator = new DatabaseSourceCreator(_mayuriDbContextFactory);
        }
        public async Task<IEnumerable<Source>> GetAllSources()
        {
            return await _sourceProvider.GetAllSources();
        }
        public async Task AddSource(Source source)
        {
            await _sourceCreator.CreateSource(source);
        }
    }
}

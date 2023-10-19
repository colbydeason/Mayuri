using Mayuri.DBContexts;
using Mayuri.Services.SourceCreators;
using Mayuri.Services.SourceProvider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task CreateSource(Source source)
        {
            await _sourceCreator.CreateSource(source);
        }

        public async Task<IEnumerable<Source>> GetCurrentSources()
        {
            return await _sourceProvider.GetCurrentSources();
        }

        public async Task<List<KeyValuePair<Guid, string>>> GetCurrentSourcesList()
        {
            return await _sourceProvider.GetCurrentSourcesList();
        }
    }
}

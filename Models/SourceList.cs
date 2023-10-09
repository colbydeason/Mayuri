using Mayuri.Services.SourceCreators;
using Mayuri.Services.SourceProvider;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mayuri.Models;

namespace Mayuri.Models
{
    public class SourceList
    {
        private readonly ISourceProvider _sourceProvider;
        private readonly ISourceCreator _sourceCreator;
        public SourceList()
        {
            _sourceProvider = App.Current.Services.GetService<ISourceProvider>();
            _sourceCreator = App.Current.Services.GetService<ISourceCreator>();
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

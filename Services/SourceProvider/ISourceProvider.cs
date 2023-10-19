using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mayuri.Services.SourceProvider
{
    public interface ISourceProvider
    {
        Task<IEnumerable<Source>> GetAllSources();
        Task<IEnumerable<Source>> GetCurrentSources();
        Task<List<KeyValuePair<Guid, string>>> GetCurrentSourcesList();
    }
}

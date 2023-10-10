using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Models
{
    public interface ISourceList
    {
        public Task<IEnumerable<Source>> GetAllSources();
        public Task AddSource(Source source);
    }
}

using Mayuri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Services.SourceCreators
{
    public interface ISourceCreator
    {
        Task CreateSource(Source source);
    }
}

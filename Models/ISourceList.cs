using Mayuri.Services.SourceCreators;
using Mayuri.Services.SourceProvider;

namespace Mayuri.Models
{
    public interface ISourceList : ISourceProvider, ISourceCreator
    {
    }
}

using Mayuri.Models;
using System.Threading.Tasks;

namespace Mayuri.Services.SourceCreators
{
    public interface ISourceCreator
    {
        Task CreateSource(Source source);
    }
}

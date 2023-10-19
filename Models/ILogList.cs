using Mayuri.Services.LogCreators;
using Mayuri.Services.LogProvider;

namespace Mayuri.Models
{
    public interface ILogList : ILogCreator, ILogProvider
    {
    }
}

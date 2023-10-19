using Mayuri.Models;
using System.Threading.Tasks;

namespace Mayuri.Services.LogCreators
{
    public interface ILogCreator
    {
        Task CreateLog(Log log);
    }
}

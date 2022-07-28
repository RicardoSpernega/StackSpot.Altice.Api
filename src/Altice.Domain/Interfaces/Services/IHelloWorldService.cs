using System.Threading.Tasks;
using Altice.Domain.Models;

namespace Altice.Domain.Interfaces.Services
{
    public interface IHelloWorldService
    {
        Task<HelloWorldResponse> Create(string userName, int userLevel);
    }
}
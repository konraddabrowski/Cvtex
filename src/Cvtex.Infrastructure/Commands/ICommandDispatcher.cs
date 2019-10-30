using System.Threading.Tasks;

namespace Cvtex.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T: ICommand;
    }
}
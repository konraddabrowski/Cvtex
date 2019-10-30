using System;
using System.Threading.Tasks;

namespace Cvtex.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask RunAsync(Func<Task> run);
    }
}
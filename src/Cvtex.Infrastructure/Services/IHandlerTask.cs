using System;
using System.Threading.Tasks;
using Cvtex.Core.Domain;

namespace Cvtex.Infrastructure.Services
{
    public interface IHandlerTask
    {
        IHandlerTask Always(Func<Task> always);
        IHandlerTask OnCustomError(
            Func<CvtexException, Task> onCustomError,
            bool propagateException = false,
            bool executeOnError = false);
        IHandlerTask OnError(
            Func<Exception, Task> onError,
            bool propagateException = false,
            bool executeOnError = false);
        IHandlerTask OnSuccess(Func<Task> onSuccess);
        IHandlerTask PropagateException();
        IHandlerTask DoNotPropagateException();
        IHandler Next();
        Task ExecuteAsync();
    }
}
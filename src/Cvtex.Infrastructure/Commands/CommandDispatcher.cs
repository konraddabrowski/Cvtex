using System;
using System.Threading.Tasks;
using Autofac;

namespace Cvtex.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command '{typeof(T).Name}' can not be null");
            }
            await _componentContext.Resolve<ICommandHandler<T>>()
                                   .HandleAsync(command);
            // var handler = _componentContext.Resolve<ICommandHandler<T>>();
            // await handler.HandleAsync(command);
        }
    }
}
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;

namespace Cvtex.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
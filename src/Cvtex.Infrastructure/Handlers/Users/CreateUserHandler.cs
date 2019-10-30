using System;
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.Services;

namespace Cvtex.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password);
        }
    }
}
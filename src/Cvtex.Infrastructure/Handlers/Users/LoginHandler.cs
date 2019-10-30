using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.Extensions;
using Cvtex.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Cvtex.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memoryCache;

        public LoginHandler(IHandler handler,
                            IUserService userService,
                            IJwtHandler jwtHandler,
                            IMemoryCache memoryCache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }

        public async Task HandleAsync(Login command)
            => await _handler
                .Run(async () => await _userService.LoginAsync(command.Email, command.Password))
                .Next().Run(async () => {
                    var user = await _userService.GetAsync(command.Email);
                    var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
                    _memoryCache.SetJwt(command.TokenId, jwt);
                })
                .ExecuteAsync();
    }
}
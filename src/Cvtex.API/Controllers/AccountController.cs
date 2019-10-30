using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cvtex.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IUserService userService,
                                 IJwtHandler jwtHandler,
                                 ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        //
        // For tests only
        //
        // [HttpGet]
        // [Route("token")]
        // public IActionResult Get()
        // {
        //     var token = _jwtHandler.CreateToken("user1@wp.pl", "admin");

        //     return new JsonResult(token);
        // }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put(ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}

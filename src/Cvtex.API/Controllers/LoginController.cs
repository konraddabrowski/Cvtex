using System;
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Cvtex.Infrastructure.Extensions;

namespace Cvtex.API.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public LoginController(IMemoryCache memoryCache,
                               ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Login command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _memoryCache.GetJwt(command.TokenId);

            return new JsonResult(jwt);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put(ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}

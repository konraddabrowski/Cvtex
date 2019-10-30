using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.DTO;
using Cvtex.Infrastructure.Services;
using Cvtex.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cvtex.API.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
                               ICommandDispatcher commandDispatcher,
                               GeneralSettings settings)
            : base(commandDispatcher)
        {
            _userService = userService;
        }

        //[Authorize(Policy = "admin")]
        // [Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            // throw new Exception("Ups...");

            var user = await _userService.GetAsync(email);

            if (user is null)
            {
                return NotFound();
            }

            var jsonResult = new JsonResult(user);

            return jsonResult;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUser command)
        {
            await DispatchAsync(command);

            return await CreatedAsync($"api/users/{command.Email}");
        }

        private async Task<CreatedResult> CreatedAsync(string uri)
        {
            return await Task.FromResult(Created(uri, null));
        }
    }
}

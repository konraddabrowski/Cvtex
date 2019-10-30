using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands;
using Cvtex.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cvtex.API.Controllers
{
    public class SchoolController : ApiControllerBase
    {
        private readonly ISchoolProvider _schoolProvider;
        public SchoolController(ICommandDispatcher commandDispatcher,
            ISchoolProvider schoolProvider)
            : base(commandDispatcher)
        {
            _schoolProvider = schoolProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schools = await _schoolProvider.BrowseAsync();

            return new JsonResult(schools);
        }
    }
}
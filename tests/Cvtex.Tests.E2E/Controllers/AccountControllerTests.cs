using System.Net;
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands.Users;
using FluentAssertions;
using NUnit.Framework;

namespace Cvtex.Tests.E2E.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Test]
        public async Task given_valid_current_and_new_password_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "current",
                NewPassword = "new"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync($"api/account/password", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}
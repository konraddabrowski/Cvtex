using System.Net;
using System.Threading.Tasks;
using Cvtex.Infrastructure.Commands.Users;
using Cvtex.Infrastructure.DTO;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Cvtex.Tests.E2E.Controllers
{
    public class UserControllerTests : ControllerTestsBase
    {
        // [SetUp]
        // public void Setup()
        // {
        // }

        [Test]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";

            var user = await GetUserAsync(email);

            user.Email.Should().BeEquivalentTo(email);
        }

        [Test]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "user11111@email.com";
            var response = await Client.GetAsync($"api/users/{email}");

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@email.com",
                Password = "secret",
                Username = "testName"
            };
            var content = GetPayload(command);
            var response = await Client.PostAsync($"api/users", content);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"api/users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }


        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
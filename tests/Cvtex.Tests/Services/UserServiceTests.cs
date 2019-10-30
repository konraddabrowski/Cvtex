using System.Threading.Tasks;
using AutoMapper;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.Repositories;
using Cvtex.Infrastructure.Services;
using Moq;
using FluentAssertions;
using NUnit.Framework;
using Cvtex.Infrastructure.DTO;
using System;

namespace Cvtex.Tests.Services
{
    public class UserServiceTests
    {
        // [SetUp]
        // public async Task Setup()
        // {
        // }

        [Test]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            var autoMapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, autoMapperMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(), "adam@wp.pl", "adamo", "secrety");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task get_async_in_user_service_should_invoke_get_async_in_user_repository_with_success()
        {
            //TODO: To fix

            var email = "user1@wp.pl";
            var fakeUser = new User(Guid.NewGuid(), email, "user1", "secret", "salt");
            var autoMapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                              .ReturnsAsync(fakeUser);
            autoMapperMock.Setup(x => x.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto {
                Email = fakeUser.Email,
                Name = fakeUser.Username
            });

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, autoMapperMock.Object);
            var user = await userService.GetAsync(It.IsAny<string>());

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
            user.Should().NotBeNull();
        }

        [Test]
        public async Task get_async_in_user_service_should_invoke_get_async_in_user_repository_with_fail()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var autoMapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, autoMapperMock.Object);
            var user = await userService.GetAsync("user100@wp.pl");

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
            user.Should().BeNull();
        }
    }
}
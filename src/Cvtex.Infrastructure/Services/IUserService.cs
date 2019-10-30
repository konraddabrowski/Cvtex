using System;
using System.Threading.Tasks;
using Cvtex.Infrastructure.DTO;

namespace Cvtex.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(Guid userId, string email, string username, string password);
        Task<UserDto> GetAsync(string email);
        Task LoginAsync(string email, string password);
    }
}
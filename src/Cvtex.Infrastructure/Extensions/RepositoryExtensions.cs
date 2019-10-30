using System;
using System.Threading.Tasks;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.Repositories;

namespace Cvtex.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);
            // if(user == null)
            // {
            //     throw new Exception($"User with email '{email}' does not exist.");
            // }

            return user;
        }
    }
}
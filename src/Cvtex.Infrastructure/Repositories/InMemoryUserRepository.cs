using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cvtex.Core.Domain;

namespace Cvtex.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.Single(x => x.Id == id));
        }

        public async Task<User> GetAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            if(user is null)
            {
                return;
            }

            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cvtex.Core.Domain;

namespace Cvtex.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
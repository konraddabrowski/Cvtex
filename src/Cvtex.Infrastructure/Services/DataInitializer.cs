using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Cvtex.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for(var i = 1; i<=10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                await _userService.RegisterAsync(userId, $"{username}@email.com", username, "secret");
            }
            for(var i = 1; i<=3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                await _userService.RegisterAsync(userId, $"{username}@email.com", username, "secret");
            }

            // await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized");
        }
    }
}
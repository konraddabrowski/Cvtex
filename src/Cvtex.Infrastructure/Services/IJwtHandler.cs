using System;
using Cvtex.Infrastructure.DTO;

namespace Cvtex.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
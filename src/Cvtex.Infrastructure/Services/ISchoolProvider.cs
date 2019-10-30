using System.Collections.Generic;
using System.Threading.Tasks;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.DTO;

namespace Cvtex.Infrastructure.Services
{
    public interface ISchoolProvider : IService
    {
        Task<IEnumerable<SchoolDto>> BrowseAsync();
        // Task<Education> GetAsync(string schoolName, string facultyName);
    }
}
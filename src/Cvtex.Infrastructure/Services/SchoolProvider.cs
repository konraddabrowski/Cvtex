using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cvtex.Core.Domain;
using Cvtex.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Cvtex.Infrastructure.Services
{
    public class SchoolProvider : ISchoolProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "schools";
        private readonly static IDictionary<string, IEnumerable<FacultyDetails>> avaibleSchools = 
        new Dictionary<string, IEnumerable<FacultyDetails>>()
        {
            ["PG"] = new List<FacultyDetails>
            {
                new FacultyDetails("WEiA", "Elektrotechnika"),
                new FacultyDetails("WEiA", "Elektronika i Automatyka"),
                new FacultyDetails("WEiA", "Mechanika i Budowa Maszyn"),
                new FacultyDetails("WTiMS", "Matematyka"),
                new FacultyDetails("WTiMS", "Fizyka")
            },
            ["UG"] = new List<FacultyDetails>
            {
                new FacultyDetails("WIMiF", "Matematyka nauczycielska")
            }
        };

        public SchoolProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<SchoolDto>> BrowseAsync()
        {
            var schools = _cache.Get<IEnumerable<SchoolDto>>(CacheKey);
            if (schools == null)
            {
                // Console.WriteLine("Getting schools from database.");
                schools = await GetAllAsync();
                _cache.Set(CacheKey, schools);
            }
            // else
            // {
            //     Console.WriteLine("Getting schools from cache.");
            // }

            return schools;
        }

        public async Task<SchoolDto> GetAsync(string school, string faculty, string subject)
        {
            if (!avaibleSchools.ContainsKey(CacheKey))
            {
                throw new Exception($"The school '{school}' is not available.");
            }
            var schools = avaibleSchools[school];
            var schoolsPerFaculty = schools.Where(x => x.Faculty == faculty);
            if (schoolsPerFaculty is null)
            {
                throw new Exception($"The faculty '{faculty}' for school '{school}' is not available.");
            }
            var selectedSchool = schools.SingleOrDefault(x => x.Subject == subject);
            if (selectedSchool is null)
            {
                throw new Exception($"The subject '{subject}' of faculty '{faculty}' for school '{school}' is not available.");
            }

            return await Task.FromResult(new SchoolDto
            {
                Name = school,
                Faculties = new List<FacultyDto>()
                {
                    new FacultyDto
                    {
                        Name = faculty,
                        Subjects = new List<string>()
                        {
                            subject
                        }
                    }
                }
            });
        }

        public async Task<IEnumerable<SchoolDto>> GetAllAsync()
            => await Task.FromResult(avaibleSchools.Select(x
            => new SchoolDto
            {
                Name = x.Key,
                Faculties = x.Value
                    .GroupBy(f => f.Faculty)
                    .Select(f => new FacultyDto
                    {
                        Name = f.Key,
                        Subjects = f.Select(s => s.Subject)
                    })
            }));

        private class FacultyDetails
        {
            public FacultyDetails(string faculty, string subject)
            {
                Faculty = faculty;
                Subject = subject;
            }

            public string Faculty { get; }
            public string Subject { get; }
        }
    }
}
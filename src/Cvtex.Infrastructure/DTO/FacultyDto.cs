using System.Collections.Generic;

namespace Cvtex.Infrastructure.DTO
{
    public class FacultyDto
    {
        public string Name { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
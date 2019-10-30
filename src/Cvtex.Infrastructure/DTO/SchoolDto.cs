using System;
using System.Collections.Generic;

namespace Cvtex.Infrastructure.DTO
{
    public class SchoolDto
    {
        public string Name { get; set; }
        public IEnumerable<FacultyDto> Faculties { get; set; }
    }
}
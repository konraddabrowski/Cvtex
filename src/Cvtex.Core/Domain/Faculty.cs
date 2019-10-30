using System;
using System.Collections.Generic;

namespace Cvtex.Core.Domain
{
    public class Faculty
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Subject> Subjects { get; protected set; }
    }
}
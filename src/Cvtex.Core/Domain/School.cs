using System;
using System.Collections.Generic;

namespace Cvtex.Core.Domain
{
    public class School
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Faculty> Faculties { get; protected set; }
    }
}
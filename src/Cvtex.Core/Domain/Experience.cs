using System;
using System.Collections.Generic;

namespace Cvtex.Core.Domain
{
    public class Experience
    {
        public Guid Id { get; protected set; }
        public string Position { get; protected set; }
        public Company Company { get; protected set; }
        public bool IsCurrentJob { get; protected set; }
        public IEnumerable<String> Reponsibilities { get; protected set; }
    }
}
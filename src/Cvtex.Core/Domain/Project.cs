using System;

namespace Cvtex.Core.Domain
{
    public class Project
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Uri Uri { get; protected set; }
        public string Info { get; protected set; }
    }
}
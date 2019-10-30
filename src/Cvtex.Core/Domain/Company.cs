using System;

namespace Cvtex.Core.Domain
{
    public class Company
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Address Address { get; protected set; }
        public string Description { get; protected set; }
        public string KRS { get; protected set; }
    }
}
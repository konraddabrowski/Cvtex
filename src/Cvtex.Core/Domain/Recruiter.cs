using System;

namespace Cvtex.Core.Domain
{
    public class Recruiter
    {
        public Guid Id { get; protected set; }
        public Guid CandidateId { get; protected set; }
    }
}
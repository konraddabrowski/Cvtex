using System;
using System.Collections.Generic;

namespace Cvtex.Core.Domain
{
    public class Candidate
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        // public IEnumerable<Education> Educations { get; protected set; }
        public IEnumerable<Skill> Competences { get; protected set; }
        public IEnumerable<Project> Projects { get; protected set; }
        public IEnumerable<Skill> Skills { get; protected set; }
        public IEnumerable<Experience> Experiences { get; protected set; }
        public string Declaration { get; protected set; }
    }
}
using System;

namespace Cvtex.Core.Domain
{
    public class Skill
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public SkillGroup Group { get; protected set; }
    }
}
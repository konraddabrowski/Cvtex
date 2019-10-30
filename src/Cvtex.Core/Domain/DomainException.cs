using System;

namespace Cvtex.Core.Domain
{
    public class DomainException : CvtexException
    {
        protected DomainException()
        {
        }

        public DomainException(string code)
            : base(code)
        {
        }

        public DomainException(string message, params object[] args)
            : base(string.Empty, message, args)
        {
        }

        public DomainException(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {
        }

        public DomainException(Exception innerEception, string message, params object[] args)
            : base(innerEception, string.Empty, message, args)
        {
        }

        public DomainException(Exception innerEception, string code, string message, params object[] args)
            : base(code, string.Format(message, args), innerEception)
        {
        }
    }
}
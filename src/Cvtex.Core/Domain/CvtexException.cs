using System;

namespace Cvtex.Core.Domain
{
    public abstract class CvtexException : Exception
    {
        public string Code { get; set; }

        protected CvtexException()
        {
        }

        public CvtexException(string code)
        {
            Code = code;
        }

        public CvtexException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public CvtexException(string code, string message, params object[] args)
            : this(null, string.Empty, message, args)
        {
        }

        public CvtexException(Exception innerEception, string message, params object[] args)
            : this(innerEception, string.Empty, message, args)
        {
        }

        public CvtexException(Exception innerEception, string code, string message, params object[] args)
            : base(string.Format(message, args), innerEception)
        {
            Code = code;
        }
    }
}
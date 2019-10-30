using System;
using Cvtex.Core.Domain;

namespace Cvtex.Infrastructure.Exceptions
{
    public class ServiceException : CvtexException
    {
        protected ServiceException()
        {
        }

        public ServiceException(string code)
            : base(code)
        {
        }

        public ServiceException(string message, params object[] args)
            : base(string.Empty, message, args)
        {
        }

        public ServiceException(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {
        }

        public ServiceException(Exception innerEception, string message, params object[] args)
            : base(innerEception, string.Empty, message, args)
        {
        }

        public ServiceException(Exception innerEception, string code, string message, params object[] args)
            : base(code, string.Format(message, args), innerEception)
        {
        }
    }
}
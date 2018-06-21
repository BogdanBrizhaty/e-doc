using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Common.Exceptions
{
    public class SessionNotStartedException : Exception
    {
        public SessionNotStartedException() : base("Session is not started")
        {
        }
    }
}
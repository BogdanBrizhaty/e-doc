using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Common.Exceptions
{
    public class AppInitializationException : Exception
    {
        public AppInitializationException() : base("Application is already being initialized")
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace eDoc.Web.Common.Exceptions
{
    public class AppExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; }
        public string SourceName { get; set; }

        public AppExceptionEventArgs(Exception exception, [CallerMemberName] string sourceName = null)
        {
            Exception = exception;
            SourceName = sourceName;
        }
    }
}
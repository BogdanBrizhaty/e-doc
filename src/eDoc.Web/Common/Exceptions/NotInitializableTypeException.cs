using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Common.Exceptions
{
    public class NotInitializableTypeException : Exception
    {
        public Type Type { get; }
        public NotInitializableTypeException(Type t) : base($"Type {t.GetType()} is not recognized as initializable.")
        {
            Type = t;
        }
    }
}
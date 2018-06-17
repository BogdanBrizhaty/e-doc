using eDoc.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Loader
{
    public static class TypeLoader
    {
        public static T Initialize<T>(Type t) where T : class
        {
            if (!typeof(IInitializable).IsAssignableFrom(t))
                throw new NotInitializableTypeException(t);
            return Activator.CreateInstance(t) as T;
        }
        //public static object Initialize(Type t)
        //{
        //    if (!t.GetType().IsAssignableFrom(typeof(IInitializable)))
        //        throw new NotInitializableTypeException(t);
        //    return Activator.CreateInstance(t);
        //}
    }
}
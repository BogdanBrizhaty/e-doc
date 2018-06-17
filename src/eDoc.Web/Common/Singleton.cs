using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Common
{
    public abstract class Singleton<T> where T: class
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var ctors = typeof(T).GetConstructors();
                    if (ctors.Any(ci => ci.IsPublic))
                        throw new Exception($"{nameof(T)} is not valid due to it's publicity");

                    _instance = Activator.CreateInstance(typeof(T)) as T;
                }

                return _instance;
            }
        }
    }
}
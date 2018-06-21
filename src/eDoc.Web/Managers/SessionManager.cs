using eDoc.Model.Managers.ContextState;
using eDoc.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace eDoc.Web.Managers
{
    public class SessionManager : IContextStateManager
    {
        private HttpSessionStateBase _session;

        public SessionManager(HttpSessionState httpSessionState)
        {
            if (httpSessionState == null)
                throw new ArgumentNullException(nameof(httpSessionState));

            _session = new HttpSessionStateWrapper(httpSessionState);
        }

        public void AddOrUpdateItem(string key, object value)
        {
            _session[key] = value;
        }

        public object GetItem(string key)
        {
            return _session[key];
        }

        public TType GetItem<TType>(string key)
        {
            var sessionValue = _session[key];
            return sessionValue == null ? default(TType) : (TType)sessionValue;
        }

        public bool ItemExists(string key)
        {
            return _session[key] == null;
        }

        public void RemoveItem(string key)
        {
            _session.Remove(key);
        }
    }
}
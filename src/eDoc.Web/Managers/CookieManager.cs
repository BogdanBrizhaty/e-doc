using eDoc.Model.Common.Enums;
using eDoc.Model.Extensions;
using eDoc.Model.Managers.ContextState;
using eDoc.Web.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eDoc.Web.Managers
{
    public class CookieManager : IContextStateManager
    {
        private HttpContextBase _context;

        public CookieManager(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            _context = httpContext;
        }
        public void AddOrUpdateItem(string key, object value)
        {
            _context
                .Response
                .Cookies
                .Set(new HttpCookie(key, value.ToString())
                {
                    Expires = DateTime.UtcNow.WithOffset(DateTimeUnit.Day.ToMinutes(App.Settings.DefaultCustomCookiesExpirationDays))
                });
        }

        public object GetItem(string key)
        {
            return _context.Request.Cookies.Get(key)?.Value;
        }

        public bool ItemExists(string key)
        {
            return _context.Request.Cookies.Get(key) == null;
        }

        public void RemoveItem(string key)
        {
            _context.Response.Cookies.Remove(key);
        }
    }
}
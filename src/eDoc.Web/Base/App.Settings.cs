using eDoc.Web.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace eDoc.Web.Base
{
    public partial class App
    {
        public static AppSettings Settings => AppSettings.Instance;
        public sealed class AppSettings : Singleton<AppSettings>
        {
            private const string DbConnectionNameKey = "DbConnectionName";
            private const string DefaultCustomCookiesExpirationDaysKey = "DefaultCustomCookiesExpirationDaysKey";

            private readonly NameValueCollection _appSettings = WebConfigurationManager.AppSettings;

            private AppSettings() 
            {
            }

            public string ActiveDbConnectionName => _appSettings[DbConnectionNameKey];
            public int DefaultCustomCookiesExpirationDays => _appSettings[DefaultCustomCookiesExpirationDaysKey] == null
                ? 1
                : Convert.ToInt32(_appSettings[DefaultCustomCookiesExpirationDaysKey]);
        }
    }
}
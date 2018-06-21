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
            private readonly NameValueCollection _appSettings = WebConfigurationManager.AppSettings;

            private AppSettings() 
            {
            }

            public string AppHost => _appSettings[AppSettingsKeys.AppHostKey];
            public string ActiveDbConnectionName => _appSettings[AppSettingsKeys.DbConnectionNameKey];
            public int DefaultCustomCookiesExpirationDays => _appSettings[AppSettingsKeys.DefaultCustomCookiesExpirationDaysKey] == null
                ? 1
                : Convert.ToInt32(_appSettings[AppSettingsKeys.DefaultCustomCookiesExpirationDaysKey]);
        }
        private static class AppSettingsKeys
        {
            public const string AppHostKey = "AppHost";
            public const string DbConnectionNameKey = "DbConnectionName";
            public const string DefaultCustomCookiesExpirationDaysKey = "DefaultCustomCookiesExpirationDays";
        }
    }
}
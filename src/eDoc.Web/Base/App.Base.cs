using eDoc.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace eDoc.Web.Base
{
    public static partial class App
    {
        public delegate void ExceptionCaughtEventHandler(object sender, AppExceptionEventArgs e);
        public static event ExceptionCaughtEventHandler ExceptionCaught;

        public delegate void AppInitializedEventHandler(object sender, EventArgs e);
        public static event AppInitializedEventHandler AppInitialized;

        public static bool IsStarted { get; private set; }

        static App()
        {

        }

        public static void Initialize()
        {
            if (IsStarted)
                throw new AppInitializationException();

            IsStarted = true;

            AppInitialized?.Invoke(null, EventArgs.Empty);
        }

        public static void OnException(Exception exception, object sender, [CallerMemberName]string sourceName = null)
        {
            ExceptionCaught?.Invoke(sender, new AppExceptionEventArgs(exception, sourceName));
        }
    }
}
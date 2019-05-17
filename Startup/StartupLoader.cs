using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class StartupLoader : IStartupLoader
    {
        public Action<IApplicationBuilder> GetConfigureDelegate(Type startupType) =>
            app => startupType.GetMethod("Configure")?.Invoke(Activator.CreateInstance(startupType), new object[] { app });
    }
}

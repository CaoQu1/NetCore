using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IStartupLoader
    {
        Action<IApplicationBuilder> GetConfigureDelegate(Type startupType);
    }
}

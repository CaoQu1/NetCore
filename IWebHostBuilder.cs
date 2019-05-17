using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseStartup(Type startupType);
        IWebHostBuilder UseServer(IServerFactory factory);
        IWebHost Build();
    }
}

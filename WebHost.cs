using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class WebHost : IWebHost
    {
        private IServiceProvider ServiceProvider;
        private Type startupType;
        public WebHost(IServiceCollection services, Type type)
        {
            this.ServiceProvider = services.BuildServiceProvider();
            this.startupType = type;
        }

        public void Start()
        {
            IApplicationBuilder applicationBuilder = ServiceProvider.GetRequiredService<IApplicationBuilderFactory>().CreateBuilder();
            ServiceProvider.GetRequiredService<IStartupLoader>().GetConfigureDelegate(startupType)(applicationBuilder);
            IServer server = ServiceProvider.GetRequiredService<IServerFactory>().CreateServer();
            server.Start(new HostingApplication(applicationBuilder.Build()));
        }
    }
}

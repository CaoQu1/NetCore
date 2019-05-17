using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class WebHostBuilder : IWebHostBuilder
    {
        private Type startupType;
        IServiceCollection services;

        public WebHostBuilder()
        {
            services = new ServiceCollection()
                .AddTransient<IStartupLoader, StartupLoader>()
                .AddTransient<IApplicationBuilderFactory, ApplicationBuilderFactory>();
        }

        public IWebHost Build() => new WebHost(services, this.startupType);
        public IWebHostBuilder UseServer(IServerFactory factory)
        {
            services.AddSingleton<IServerFactory>(factory);
            return this;
        }
        public IWebHostBuilder UseStartup(Type startupType)
        {
            this.startupType = startupType;
            return this;
        }
    }
}

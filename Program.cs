using System;

namespace NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseServer(new HttpListenerServerFactory(""))
                .UseStartup(typeof(Startup))
                .Build()
                .Start();
        }
    }
}

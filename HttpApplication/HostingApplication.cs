using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    public class HostingApplication : IHttpApplication<Context>
    {
        private RequestDelegate Application;

        public HostingApplication(RequestDelegate application)
        {
            this.Application = application;
        }

        public Context CreateContext(IFeatureCollection featureCollection)
        {
            DefaultHttpContext defaultHttpContext = new DefaultHttpContext(featureCollection);

            return new Context
            {
                HttpContext = defaultHttpContext,
                StartTimestamp = Stopwatch.GetTimestamp()
            };
        }

        public void DisposeContext(Context context, Exception exception) => context.Scope?.Dispose();

        public Task ProcessRequestAsync(Context context) => this.Application(context.HttpContext);
    }


    public class Context
    {
        public HttpContext HttpContext { get; set; }
        public IDisposable Scope { get; set; }
        public long StartTimestamp { get; set; }
    }
}

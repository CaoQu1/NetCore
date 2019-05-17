using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NetCore
{
    public class HttpListenerServer : IServer
    {
        public HttpListener Listener { get; }

        public HttpListenerServer(string url)
        {
            this.Listener = new HttpListener();
            this.Listener.Prefixes.Add("http://localhost:2323/");
        }


        public void Start<TContext>(IHttpApplication<TContext> application)
        {
            this.Listener.Start();
            while (true)
            {
                HttpListenerContext context = this.Listener.GetContext();
                HttpListenerContextFeature httpListenerContextFeature = new HttpListenerContextFeature(context);

                FeatureCollection feature = new FeatureCollection();
                feature.Set<IHttpRequestFeature>(httpListenerContextFeature);
                feature.Set<IHttpResponseFeature>(httpListenerContextFeature);

                application.ProcessRequestAsync(application.CreateContext(feature)).ContinueWith(_ => context.Response.Close());
            }
        }
    }
}

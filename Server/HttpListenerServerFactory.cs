using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class HttpListenerServerFactory : IServerFactory
    {
        private string url;

        public HttpListenerServerFactory(string url)
        {
            this.url = url;
        }

        public IServer CreateServer()
        {
            return new HttpListenerServer(url);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NetCore
{
    public class HttpListenerContextFeature : IHttpRequestFeature, IHttpResponseFeature
    {
        public HttpListenerContext Context { get; }
        public HttpListenerContextFeature(HttpListenerContext context)
        {
            this.Context = context;
            this.OutputStream = context.Response.OutputStream;
            this.Url = context.Request.Url;
        }

        public long ContentLength64
        {
            get { return this.Context.Response.ContentLength64; }
            set { this.Context.Response.ContentLength64 = value; }
        }

        public Stream OutputStream { get; }
        public Uri Url { get; }

        public string ContentType
        {
            get { return this.Context.Response.ContentType; }
            set { this.Context.Response.ContentType = value; }
        }

        public int StatusCode
        {
            get { return this.Context.Response.StatusCode; }
            set { this.Context.Response.StatusCode = value; }
        }
    }
}

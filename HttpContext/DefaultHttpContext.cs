using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class DefaultHttpContext : HttpContext
    {
        public IFeatureCollection FeatureCollection;

        public DefaultHttpContext(IFeatureCollection featureCollection)
        {
            this.FeatureCollection = featureCollection;
            this.HttpRequest = new DefaultHttpRequest(this);
            this.HttpResponse = new DefaultHttpResponse(this);
        }

        public override HttpRequest HttpRequest { get; }

        public override HttpResponse HttpResponse { get; }
    }
}

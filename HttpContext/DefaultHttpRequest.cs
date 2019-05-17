using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class DefaultHttpRequest : HttpRequest
    {
        private IHttpRequestFeature HttpRequestFeature;

        public DefaultHttpRequest(DefaultHttpContext defaultHttpContext)
        {
            this.HttpRequestFeature = defaultHttpContext.FeatureCollection.Get<IHttpRequestFeature>();
        }

        public override Uri Uri => this.HttpRequestFeature.Url;
    }
}

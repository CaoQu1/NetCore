using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCore
{
    public class DefaultHttpResponse : HttpResponse
    {
        public IHttpResponseFeature HttpResponseFeature { get; private set; }

        public override Stream OutputStream
        {
            get { return this.HttpResponseFeature.OutputStream; }
        }

        public override string ContentType
        {
            get { return this.HttpResponseFeature.ContentType; }
            set { this.HttpResponseFeature.ContentType = value; }
        }

        public override int StatusCode
        {
            get { return this.HttpResponseFeature.StatusCode; }
            set { this.HttpResponseFeature.StatusCode = value; }
        }

        public DefaultHttpResponse(DefaultHttpContext context)
        {
            this.HttpResponseFeature = context.FeatureCollection.Get<IHttpResponseFeature>();
        }

    }
}

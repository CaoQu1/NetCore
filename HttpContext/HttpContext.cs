using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public abstract class HttpContext
    {
        public abstract HttpRequest HttpRequest { get; }

        public abstract HttpResponse HttpResponse { get; }
    }
}

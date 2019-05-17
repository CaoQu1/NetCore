using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public abstract class HttpRequest
    {
        public abstract Uri Uri { get; }
    }
}

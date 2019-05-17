using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IApplicationBuilder
    {
        RequestDelegate Build();

        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
    }
}

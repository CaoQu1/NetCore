using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NetCore
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private static readonly IList<Func<RequestDelegate, RequestDelegate>> middlewares = new List<Func<RequestDelegate, RequestDelegate>>();

        public RequestDelegate Build()
        {
            RequestDelegate seed = context => Task.Run(() => { });
            var requestDelegate = middlewares.Reverse().Aggregate(seed, (next, current) => current(next));
            return requestDelegate;
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            middlewares.Add(middleware);
            return this;
        }
    }
}

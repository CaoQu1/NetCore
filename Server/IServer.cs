using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IServer
    {
        void Start<TContext>(IHttpApplication<TContext> application);
    }
}

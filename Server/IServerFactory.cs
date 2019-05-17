using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IServerFactory
    {
        IServer CreateServer();
    }
}

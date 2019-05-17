using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public class ApplicationBuilderFactory : IApplicationBuilderFactory
    {
        public IApplicationBuilder CreateBuilder()
        {
            return new ApplicationBuilder();
        }
    }
}

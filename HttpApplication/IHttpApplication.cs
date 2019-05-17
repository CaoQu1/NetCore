using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    public interface IHttpApplication<TContext>
    {
        TContext CreateContext(IFeatureCollection featureCollection);

        Task ProcessRequestAsync(TContext context);

        void DisposeContext(TContext context, Exception exception);
    }
}

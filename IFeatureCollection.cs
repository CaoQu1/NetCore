using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore
{
    public interface IFeatureCollection
    {
        TFeature Get<TFeature>();

        void Set<TFeature>(TFeature instance);
    }
}

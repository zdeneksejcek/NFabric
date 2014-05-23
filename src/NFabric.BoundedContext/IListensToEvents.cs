using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public interface IListensToEvents
    {
        IEnumerable<EventDescriptor> GetEvents();
    }
}

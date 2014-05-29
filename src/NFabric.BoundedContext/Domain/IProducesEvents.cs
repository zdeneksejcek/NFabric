using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Domain
{
    public interface IProducesEvents
    {
        IEnumerable<SequencedEvent> GetUncommitedSequencedEvents();
    }
}


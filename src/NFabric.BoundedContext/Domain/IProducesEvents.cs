using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Domain
{
    public interface IProducesEvents
    {
        IList<SequencedEvent> GetUncommitedSequencedEvents();
    }
}


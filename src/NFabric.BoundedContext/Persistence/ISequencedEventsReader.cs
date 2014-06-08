using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.BoundedContext.Persistence
{
    public interface ISequencedEventsReader
    {
        IList<SequencedEvent> GetEvents(Guid aggregateId, int? withSequenceHigherThan = null);
    }
}
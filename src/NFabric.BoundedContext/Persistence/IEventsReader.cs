using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Persistence
{
    public interface IEventsReader
    {
        IList<EventRecord> GetStream(Guid aggregateId, int? withSequenceHigherThan = null);
    }
}
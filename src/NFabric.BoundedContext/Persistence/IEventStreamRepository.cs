using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.BoundedContext.Persistence
{
    public interface IEventStreamRepository
    {
        EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = null);

        void Append(IList<SequencedEvent> events);
    }
}
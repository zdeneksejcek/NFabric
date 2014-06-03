using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Persistence
{
    public interface IEventStreamRepository
    {
        EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = null);

        void Append(EventStream stream);
    }
}
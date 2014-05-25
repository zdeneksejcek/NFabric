using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public interface IEventRecordsRepository
    {
        EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = null);

        void Append(EventStream stream);
    }
}
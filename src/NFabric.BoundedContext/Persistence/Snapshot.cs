using System;

namespace NFabric.BoundedContext.Persistence
{
    public class Snapshot
    {
        public Guid AggregateId { get; private set; }
        public int TopSequence { get; private set; }

        public Snapshot(Guid aggregateId, int topSequence)
        {
            AggregateId = aggregateId;
            TopSequence = topSequence;
        }
    }
}
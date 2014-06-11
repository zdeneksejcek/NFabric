using System;
using NFabric.Contracts;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public class SequencedEvent
    {
        public Guid AggregateId { get; private set; }
        public int Sequence { get; private set; }
        public IEvent Event { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public SequencedEvent(Guid aggregateId, int sequence, IEvent @event, DateTime createdOn) {
            AggregateId = aggregateId;
            Sequence = sequence;
            Event = @event;
            CreatedOn = createdOn;
        }
    }
}


using System;

namespace NFabric.BoundedContext.Domain
{
    public class SequencedEvent
    {
        public Guid AggregateId { get; private set; }
        public int Sequence { get; private set; }
        public object Event { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public SequencedEvent(Guid aggregateId, int sequence, object @event, DateTime createdOn) {
            AggregateId = aggregateId;
            Sequence = sequence;
            Event = @event;
            CreatedOn = createdOn;
        }
    }
}


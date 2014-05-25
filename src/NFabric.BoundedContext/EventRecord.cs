using System;

namespace NFabric.BoundedContext
{
    public class EventRecord
    {
        public Guid AggregateId { get; private set; }
        public int Sequence { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public string Event { get; private set; }
        public string AdditionalData { get; private set; }

        public EventRecord(Guid aggregateId, int sequence, string @event, string additionalData = null)
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            CreatedOn = DateTime.UtcNow;
            Event = @event;
            AdditionalData = additionalData;
        }
    }
}
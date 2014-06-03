using System;

namespace NFabric.BoundedContext.Persistence
{
    public class EventRecord
    {
        public Guid AggregateId { get; private set; }
        public int Sequence { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string TypeName { get; private set; }
        public byte[] Event { get; private set; }
        public byte[] AdditionalData { get; private set; }

        public EventRecord(Guid aggregateId, int sequence, string typeName, byte[] @event, byte[] additionalData = null)
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            CreatedOn = DateTime.UtcNow;
            TypeName = typeName;
            Event = @event;
            AdditionalData = additionalData;
        }
    }
}
using System;

namespace NFabric.BoundedContext.Persistence
{
    [Serializable]
    public class EventRecord
    {
        public Guid AggregateId { get; private set; }
        public int Sequence { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string TypeName { get; private set; }
        public string BoundedContext { get; private set; }
        public string SerializedEvent { get; private set; }
        public string AdditionalData { get; private set; }

        public EventRecord(Guid aggregateId, int sequence, string typeName, string boundedContext, string serializedEvent, string additionalData = null)
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            CreatedOn = DateTime.UtcNow;
            TypeName = typeName;
            BoundedContext = boundedContext;
            SerializedEvent = serializedEvent;
            AdditionalData = additionalData;
        }
    }
}
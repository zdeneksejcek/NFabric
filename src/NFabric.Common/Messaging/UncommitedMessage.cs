using System;

namespace NFabric.Common.Messaging
{
    [Serializable]
    public class UncommitedMessage
    {
        public Guid AggregateId { get; private set; }
        public string Type { get; private set; }
        public string BoundedContext { get; private set; }
        public string Name { get; private set; }
        public int Sequence { get; private set; }
        public string Body { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public UncommitedMessage(string type, string boundedContext, string name, Guid aggregateId, int sequence, DateTime createdOn, string body)
        {
            AggregateId = aggregateId;
            Type = type;
            BoundedContext = boundedContext;
            Name = name;
            Body = body;
            Sequence = sequence;
            CreatedOn = createdOn;
        }
    }
}
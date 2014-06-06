using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NFabric.Infrastructure.Mongo
{
    public class EventDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        public Guid AggId { get; private set; }
        public int Sequence { get; private set; }
        public string Name { get; private set; }
        public string BoundedContext { get; private set; }
        public string SerializedEvent { get; private set; }
        public string AdditionalData { get; private set; }

        public EventDocument(Guid aggId, int sequence, string name, string boundedContext, string serializedEvent, string serializedAdditionalData)
        {
            AggId = aggId;
            Sequence = sequence;
            Name = name;
            BoundedContext = boundedContext;
            SerializedEvent = serializedEvent;
            AdditionalData = serializedAdditionalData;
        }
    }
}
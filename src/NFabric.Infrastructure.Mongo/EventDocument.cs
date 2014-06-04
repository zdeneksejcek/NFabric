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
        public string TypeName { get; private set; }
        public string SerializedEvent { get; private set; }
        public string AdditionalData { get; private set; }

        public EventDocument(Guid aggId, int sequence, string typeName, string serializedEvent, string serializedAdditionalData)
        {
            AggId = aggId;
            Sequence = sequence;
            TypeName = typeName;
            SerializedEvent = serializedEvent;
            AdditionalData = serializedAdditionalData;
        }
    }
}
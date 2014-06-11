using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;
using System.Linq;
using NFabric.Contracts;

namespace NFabric.BoundedContext.Persistence
{
    public class SequencedEventsReader : ISequencedEventsReader
    {
        IEventsReader _reader;
        ServiceRegistry _registry;

        public SequencedEventsReader(IEventsReader reader, ServiceRegistry registry)
        {
            _reader = reader;
            _registry = registry;
        }

        public System.Collections.Generic.IList<SequencedEvent> GetEvents(Guid aggregateId, int? withSequenceHigherThan = default(int?))
        {
            var records = _reader.GetStream(aggregateId, withSequenceHigherThan);

            return records.Select(
                p=>new SequencedEvent(
                    p.AggregateId,
                    p.Sequence,
                    DeserializeEvent(p.SerializedEvent, p.TypeName, p.BoundedContext) as IEvent, 
                    p.CreatedOn)
            ).ToList();
        }

        private object DeserializeEvent(string body, string messageName, string messageBoundedContext) {
            var eventDescriptor = _registry.GetMessageDescriptor("event", messageName, messageBoundedContext);

            if (eventDescriptor != null)
                return Serializer.Deserialize(body, eventDescriptor.Type);

            throw new Exception("There is no registered listener for this message type");
        }

    }
}
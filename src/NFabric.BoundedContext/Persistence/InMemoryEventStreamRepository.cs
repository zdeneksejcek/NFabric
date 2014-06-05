using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.BoundedContext.Persistence
{
    public class InMemoryEventStreamRepository : IEventStreamRepository
    {
        private List<SequencedEvent> _uncommitedEvents = new List<SequencedEvent>();
        public IList<SequencedEvent> UncommitedEvents { get { return _uncommitedEvents; } }

        public InMemoryEventStreamRepository() {

        }

        public EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = default(int?))
        {
            //return _persistentRepository.GetStream(aggregateId, withSequenceHigherThan);

            return new EventStream(null);
        }

        public void Append(IList<SequencedEvent> events)
        {
            _uncommitedEvents.AddRange(events);
        }
    }
}


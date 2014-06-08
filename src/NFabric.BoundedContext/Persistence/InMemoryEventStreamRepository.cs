using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.BoundedContext.Persistence
{
    public class InMemoryEventsRepository : IEventsRepository
    {
        private List<SequencedEvent> _uncommitedEvents = new List<SequencedEvent>();
        public IList<SequencedEvent> UncommitedEvents { get { return _uncommitedEvents; } }

        public void Append(IList<SequencedEvent> events)
        {
            _uncommitedEvents.AddRange(events);
        }
    }
}
using System.Collections.Generic;
using System;
using System.Linq;

namespace NFabric.BoundedContext.Domain
{
    public abstract class AggregateWithES : IProducesEvents
    {
        protected AggregateEvents Events { get; private set; }

        public Guid Id { get; protected set; }

        public AggregateWithES() {
            Events = new AggregateEvents();
        }

        public AggregateWithES(IEnumerable<object> commitedEvents) {
            Events = new AggregateEvents();
            Events.UpdateCommited(commitedEvents);
        }

        public AggregateWithES(int lastCommitedSequence, IEnumerable<object> commitedEvents) {
            Events = new AggregateEvents(lastCommitedSequence);
            Events.UpdateCommited(commitedEvents);
        }

        IEnumerable<SequencedEvent> IProducesEvents.GetUncommitedSequencedEvents()
        {
            return ((IProducesEvents)Events).GetUncommitedSequencedEvents();
        }
    }
}
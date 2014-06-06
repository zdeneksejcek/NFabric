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
            Events = new AggregateEvents(() => Id);
        }

        public AggregateWithES(IEnumerable<SequencedEvent> commitedEvents) {
            Events = new AggregateEvents(() => Id);
            Events.UpdateCommited(commitedEvents);
        }

        public AggregateWithES(int lastCommitedSequence, IEnumerable<SequencedEvent> commitedEvents) {
            Events = new AggregateEvents(lastCommitedSequence, () => Id);
            Events.UpdateCommited(commitedEvents);
        }

        IList<SequencedEvent> IProducesEvents.GetUncommitedSequencedEvents()
        {
            return ((IProducesEvents)Events).GetUncommitedSequencedEvents();
        }
    }
}
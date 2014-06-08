using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public abstract class AggregateWithES : IProducesEvents
    {
        [NonSerialized]
        private AggregateEvents _events;

        public AggregateEvents Events { get { return _events; } }

        public Guid Id { get; protected set; }

        protected AggregateWithES() {
            _events = new AggregateEvents(() => Id);
        }

        protected AggregateWithES(IEnumerable<SequencedEvent> commitedEvents) {
            _events = new AggregateEvents(() => Id);
            _events.UpdateCommited(commitedEvents);
        }

        protected AggregateWithES(int lastCommitedSequence, IEnumerable<SequencedEvent> commitedEvents) {
            _events = new AggregateEvents(lastCommitedSequence, () => Id);
            _events.UpdateCommited(commitedEvents);
        }

        IList<SequencedEvent> IProducesEvents.GetUncommitedSequencedEvents()
        {
            return ((IProducesEvents)_events).GetUncommitedSequencedEvents();
        }

        protected abstract void InitializeEventHandlers();

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            InitializeEventHandlers();
        }

        [OnDeserializing]
        internal void OnDeserializing(StreamingContext context)
        {
            _events = new AggregateEvents(() => Id);
        }

    }
}
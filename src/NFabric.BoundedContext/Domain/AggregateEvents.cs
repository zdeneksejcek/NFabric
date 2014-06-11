using System;
using System.Collections.Generic;
using System.Linq;
using NFabric.Contracts;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public class AggregateEvents : IProducesEvents
    {
        private List<Handler> _handlers = new List<Handler>();

        [NonSerialized]
        private List<IEvent> _uncommitedEvents;

        private List<IEvent> UncommitedEvents
        {
            get { return _uncommitedEvents ?? (_uncommitedEvents = new List<IEvent>()); }
        } 
        
        public int LastCommitedSequence { get; private set; }
        public Func<Guid> GetAggregateIdMethod = null;

        public AggregateEvents(Func<Guid> getAggregateIdMethod) {
            LastCommitedSequence = -1;
            GetAggregateIdMethod = getAggregateIdMethod;
        }

        public AggregateEvents(int lastCommitedSequence, Func<Guid> getAggregateIdMethod) {
            LastCommitedSequence = lastCommitedSequence;
            GetAggregateIdMethod = getAggregateIdMethod;
        }

        public void Handles<TEvent>(Action<TEvent> @handler) where TEvent : IAggregateEvent {
            _handlers.Add(
                new Handler(
                    typeof(TEvent),
                    null,
                    e => @handler((TEvent)e)));
        }

        public void Handles<TEvent>(Guid entityId, Action<TEvent> @handler) where TEvent : IEntityEvent
        {
            _handlers.Add(
                new Handler(
                    typeof(TEvent),
                    entityId,
                    e => @handler((TEvent)e)));
        }

        IList<SequencedEvent> IProducesEvents.GetUncommitedSequencedEvents()
        {
            Guid aggregateId = GetAggregateIdMethod();
            var list = new List<SequencedEvent>();
            for (int i = 0; i < UncommitedEvents.Count; i++)
                list.Add(
                    new SequencedEvent(
                        aggregateId,
                        LastCommitedSequence + i +1,
                        UncommitedEvents.ElementAt(i), DateTime.UtcNow));

            return list;
        }

        public void Update(IEvent @event) {
            ApplyUncommited(@event);

            UncommitedEvents.Add(@event);
        }

        public void UpdateCommited(IEnumerable<SequencedEvent> events) {
            foreach (var e in events)
                Apply(e);
        }

        private void ApplyUncommited(IEvent @event)
        {
            var handler = GetHandler(@event);
            if (handler != null)
                handler.Handle(@event);
        }

        private void Apply(SequencedEvent @event)
        {
            var handler = GetHandler(@event.Event);
            if (handler != null)
            {
                handler.Handle(@event.Event);
                LastCommitedSequence += 1;
            }
        }

        private Handler GetHandler(IEvent @event)
        {
            Handler handler = null;

            if (@event is IEntityEvent)
                handler =
                    _handlers.FirstOrDefault(
                        p => p.Type == @event.GetType() && p.EntityId == ((IEntityEvent) @event).EntityId);

            if (@event is IAggregateEvent)
                handler = _handlers.FirstOrDefault(p => p.Type == @event.GetType());

            if (handler == null)
                throw new UnhandledEvent(@event);

            return handler;
        }
    }
}
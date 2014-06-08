using System;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public class AggregateEvents : IProducesEvents
    {
        private List<Handler> _handlers = new List<Handler>();

        [NonSerialized]
        private List<object> _uncommitedEvents;

        private List<object> UncommitedEvents
        {
            get { return _uncommitedEvents ?? (_uncommitedEvents = new List<object>()); }
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

        public void Handles<TEvent>(Action<TEvent> @handler) {
            _handlers.Add(
                new Handler(
                    typeof(TEvent),
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

        public void Update(object @event) {
            ApplyUncommited(@event);

            UncommitedEvents.Add(@event);
        }

        public void UpdateCommited(IEnumerable<SequencedEvent> events) {
            foreach (var e in events)
                Apply(e);
        }

        private void ApplyUncommited(object @event) {
            var handler = _handlers.FirstOrDefault(p => p.Type == @event.GetType());
            if (handler != null)
                handler.Handle(@event);
        }

        private void Apply(SequencedEvent @event) {
            var handler = _handlers.FirstOrDefault(p => p.Type == @event.Event.GetType());
            if (handler != null)
            {
                handler.Handle(@event.Event);
                LastCommitedSequence += 1;
            }
        }
    }
}
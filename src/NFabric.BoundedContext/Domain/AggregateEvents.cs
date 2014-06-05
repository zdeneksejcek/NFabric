using System;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext.Domain
{
    public class AggregateEvents : IProducesEvents
    {
        private List<Handler> _handlers = new List<Handler>();
        private List<object> _uncommitedEvents = new List<object>();
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
            for (int i = 0; i < _uncommitedEvents.Count; i++)
                list.Add(
                    new SequencedEvent(
                        aggregateId,
                        LastCommitedSequence + i + 1,
                        _uncommitedEvents.ElementAt(i), DateTime.UtcNow));

            return list;
        }

        public void Update(object @event) {
            Apply(@event);

            _uncommitedEvents.Add(@event);
        }

        public void UpdateCommited(IEnumerable<object> events) {
            foreach (var e in events)
                Apply(e);
        }

        private void Apply(object @event) {
            var handler = _handlers.Where(p => p.Type == @event.GetType()).FirstOrDefault();
            if (handler != null)
                handler.Handle(@event);
        }
    }
}
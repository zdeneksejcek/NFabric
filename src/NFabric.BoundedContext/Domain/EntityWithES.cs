using System;
using System.Runtime.Serialization;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public abstract class EntityWithES
    {
        protected AggregateEvents Events { get; set; }

        public Guid Id { get; protected set; }

        protected EntityWithES(AggregateEvents events, Guid id)
        {
            Id = id;
            Events = events;

            InitializeEventHandlers();
        }

        protected abstract void InitializeEventHandlers();

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            InitializeEventHandlers();
        }

    }
}
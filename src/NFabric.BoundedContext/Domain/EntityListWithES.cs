using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Domain
{
    public class EntityCollectionWithES<TEntity, TCollection> where TCollection : ICollection<TEntity>, new()
    {
        protected AggregateEvents Events { get; set; }

        protected TCollection Collection { get; private set; }

        public EntityCollectionWithES(AggregateEvents events)
        {
            Events = events;
            Collection = new TCollection();
        }
    }
}


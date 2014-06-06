using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Domain
{
    public class EntityCollectionWithES<TEntity, TCollection> where TCollection : ICollection<TEntity>, new()
    {
        protected AggregateEvents Events { get; set; }

        protected TCollection Collection { get; private set; }

        private  Func<Guid> _getAggregateIdMethod;
        protected Guid AggregateId {
            get {
                return _getAggregateIdMethod();
            }
        }

        public EntityCollectionWithES(AggregateEvents events, Func<Guid> getAggregateIdMethod)
        {
            Events = events;
            Collection = new TCollection();
            _getAggregateIdMethod = getAggregateIdMethod;
        }
    }
}


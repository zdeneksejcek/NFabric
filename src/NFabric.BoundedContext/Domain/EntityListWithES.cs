using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public abstract class EntityCollectionWithES<TEntity> : List<TEntity>
    {
        protected Guid AggregateId {
            get { return _getParentAggregate().Id; }
        }

        protected AggregateEvents Events {
            get { return _getParentAggregate().Events; }
        }

        private Func<AggregateWithES> _getParentAggregate;

        protected EntityCollectionWithES(Func<AggregateWithES> getParentAggregate)
        {
            _getParentAggregate = getParentAggregate;
            InitializeEventHandlers();
        }

        protected abstract void InitializeEventHandlers();

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            InitializeEventHandlers();
        }
    }
}


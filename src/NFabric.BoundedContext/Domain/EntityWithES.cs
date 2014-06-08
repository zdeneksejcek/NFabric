﻿using System;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    public class EntityWithES
    {
        protected AggregateEvents Events { get; set; }

        public Guid Id { get; protected set; }

        public EntityWithES(AggregateEvents events) {
            Events = events;
        }
    }
}
using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public class EventStream
    {
        public IList<EventRecord> Events { get; private set; }

        public EventStream(IList<EventRecord> events)
        {
            Events = events;
        }
    }
}
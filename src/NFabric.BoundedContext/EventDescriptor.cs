using System;

namespace NFabric.BoundedContext
{
    public sealed class EventDescriptor
    {
        public string EventName { get; private set; }
        public Type EventType { get; private set; }

        public EventDescriptor(string name, Type type) {
            EventName = name;
            EventType = type;
        }
    }
}
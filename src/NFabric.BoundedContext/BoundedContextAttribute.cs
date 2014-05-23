using System;

namespace NFabric.BoundedContext
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class BoundedContextAttribute : Attribute
    {
        public Type ListensToEventsType { get; private set; }

        public BoundedContextAttribute(Type listensToEvents) {
            ListensToEventsType = listensToEvents;
        }
    }
}

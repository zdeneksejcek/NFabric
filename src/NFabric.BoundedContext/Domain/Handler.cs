using System;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    internal class Handler
    {
        public Type Type { get; private set; }
        public Action<object> Handle { get; private set; }

        public Handler(Type @event, Action<object> handle)
        {
            Type = @event;
            Handle = handle;
        }
    }
}
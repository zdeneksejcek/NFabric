using System;
using System.Diagnostics;

namespace NFabric.BoundedContext.Domain
{
    [Serializable]
    [DebuggerDisplay("{Type.Name}")]
    internal class Handler
    {
        public Type Type { get; private set; }
        public Action<object> Handle { get; private set; }

        public Guid? EntityId { get; private set; }

        public Handler(Type @event, Guid? entityId, Action<object> handle)
        {
            Type = @event;
            Handle = handle;
            EntityId = entityId;
        }
    }
}
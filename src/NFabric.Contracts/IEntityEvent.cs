using System;

namespace NFabric.Contracts
{
    public interface IEntityEvent : IEvent
    {
        Guid EntityId { get; }
    }
}
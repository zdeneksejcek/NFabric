using System;

namespace NFabric.Contracts
{
    public interface ICommand
    {
        Guid AggregateId { get; }
    }
}

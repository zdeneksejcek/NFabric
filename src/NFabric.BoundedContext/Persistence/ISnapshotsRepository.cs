using System;

namespace NFabric.BoundedContext.Persistence
{
    public interface ISnapshotsRepository
    {
        Snapshot GetBy(Guid aggregateId);
        void Save(Snapshot snapshot);
    }
}
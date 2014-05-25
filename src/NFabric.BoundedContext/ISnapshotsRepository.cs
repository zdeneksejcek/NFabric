using System;

namespace NFabric.BoundedContext
{
    public interface ISnapshotsRepository
    {
        Snapshot GetBy(Guid aggregateId);
        void Save(Snapshot snapshot);
    }
}
using System;

namespace NFabric.BoundedContext.Persistence
{
    public class InMemorySnapshotRepository : ISnapshotsRepository
    {
        public InMemorySnapshotRepository()
        {

        }

        public Snapshot GetBy(Guid aggregateId)
        {
            return new Snapshot(Guid.Empty, 0);
        }

        public void Save(Snapshot snapshot)
        {

        }
    }
}
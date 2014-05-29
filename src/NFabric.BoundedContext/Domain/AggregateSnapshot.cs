using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Domain
{
    public class AggregateSnapshot<T>
    {
        public T Snapshot { get; private set; }
        public int ShapshotLatestVersion { get; private set; }
        public IEnumerable<object> CommitedEvents { get; private set; }

        public AggregateSnapshot(T snapshot, IEnumerable<object> commitedEvents, int snapshotLatestVersion)
        {
            Snapshot = snapshot;
            CommitedEvents = commitedEvents;
            ShapshotLatestVersion = snapshotLatestVersion;
        }
    }
}
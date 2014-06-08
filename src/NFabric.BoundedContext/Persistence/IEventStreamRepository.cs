using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.BoundedContext.Persistence
{
    public interface IEventsRepository
    {
        void Append(IList<SequencedEvent> events);
    }
}
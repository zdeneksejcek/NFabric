using System;

namespace NFabric.BoundedContext.Persistence
{
    public class InMemoryEventStreamRepository : IEventStreamRepository
    {
        /*
        IEventStreamRepository _persistentRepository;

        public InMemoryEventStreamRepository(IEventStreamRepository persistentRepository)
        {
            _persistentRepository = persistentRepository;
        }
        */

        public EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = default(int?))
        {
            //return _persistentRepository.GetStream(aggregateId, withSequenceHigherThan);

            return new EventStream(null);
        }

        public void Append(EventStream stream)
        {

        }
    }
}


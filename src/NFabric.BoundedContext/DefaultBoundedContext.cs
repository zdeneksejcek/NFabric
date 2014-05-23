using System;
using NFabric.Common;

namespace NFabric.BoundedContext
{
    public abstract class DefaultBoundedContext : IBoundedContext
    {
        public abstract string Name { get; }

        public abstract IListensToEvents ListensToEventsProvider { get; }

        public IMessageSerializer MessageSerializer
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IMessageDeserializer MessageDeserializer
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}


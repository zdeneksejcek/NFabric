using System;
using NFabric.Common;
using System.Collections.Generic;

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

        public abstract IList<object> ExecuteCommand(object obj);
    }
}
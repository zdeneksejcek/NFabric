using System;
using NFabric.Common;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        string Name {get;}
        IListensToEvents ListensToEventsProvider { get; }

        IMessageSerializer MessageSerializer {get;}
        IMessageDeserializer MessageDeserializer {get;}
    }
}
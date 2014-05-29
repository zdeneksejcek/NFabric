using System;
using NFabric.Common;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        string Name {get;}
        IListensToEvents ListensToEventsProvider { get; }

        IMessageSerializer MessageSerializer { get; }
        IMessageDeserializer MessageDeserializer { get; }

        IList<object> ExecuteCommand(object command);
    }
}
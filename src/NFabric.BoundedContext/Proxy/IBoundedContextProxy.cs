using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Proxy
{
    public interface IBoundedContextProxy
    {
        IList<object> ExecuteCommand(object command);

        IList<object> ExecuteEvent(object @event);
    }
}
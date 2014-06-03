using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        string GetName();

        IList<object> ExecuteCommand(object command);
        IList<object> ExecuteEvent(object @event);

        HandledMessages GetHandledMessages();
    }
}
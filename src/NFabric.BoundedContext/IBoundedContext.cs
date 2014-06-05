using System;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        string GetName();

        UncommitedMessage[] ExecuteMessage(Message message);

        HandledMessages GetHandledMessages();
    }
}
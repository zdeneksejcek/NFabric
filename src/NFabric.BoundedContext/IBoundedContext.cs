using System;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        string GetName();

        Message[] ExecuteMessage(Message message);

        HandledMessages GetHandledMessages();
    }
}
using System;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.BoundedContext
{
    public interface IBoundedContext
    {
        NFabric.Common.Messaging.UncommitedMessage[] ExecuteMessage(NFabric.Common.Messaging.Message message);

        string GetName();
    }
}
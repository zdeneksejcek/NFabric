using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Proxy
{
    public interface IBoundedContextProxy
    {
        NFabric.Common.Messaging.Message[] ExecuteMessage(NFabric.Common.Messaging.Message message);
        string GetName();
    }
}
using System;
using System.Collections.Generic;

namespace NFabric.BoundedContext
{
    [Serializable]
    public class HandledMessages
    {
        public IList<MessageDescriptor> Messages { get; private set;}

        public HandledMessages(IList<MessageDescriptor> messages)
        {
            Messages = messages;
        }
    }
}


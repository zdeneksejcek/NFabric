using System;

namespace NFabric.BoundedContext.Proxy
{
    public class CommandMessage
    {
        public string Type { get; private set; }

        public CommandMessage(dynamic message)
        {
            Type = message.Type;
        }
    }
}


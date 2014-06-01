using System;

namespace NFabric.Host.Messaging
{
    public class CommandMessage
    {
        public string BoundedContext { get; private set; }
        public string CommandName { get; private set; }

        public CommandMessage(string boundedContext, string commandName)
        {
            BoundedContext = boundedContext;
            CommandName = commandName;
        }
    }
}


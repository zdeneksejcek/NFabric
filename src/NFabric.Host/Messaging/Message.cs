using System;

namespace NFabric.Host.Messaging
{
    public class Message : MarshalByRefObject
    {
        public string Type { get; private set; }

        public Message(string type) {
            Type = type;
        }
    }
}
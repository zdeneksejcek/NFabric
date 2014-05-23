using System;
using System.Threading;

namespace NFabric.Common
{
    public class MessageEnvelope
    {
        public MessageType Type { get; private set; }
        public Guid Id { get; private set; }
        public byte[] Payload { get; private set; }
        public MessageName Name { get; private set; }

        public MessageEnvelope(MessageType type, string messageName, byte[] payload)
        {
            Id = Guid.NewGuid();

            this.Type = type;
            Payload = payload;
            Name = new MessageName(messageName);
        }
    }
}
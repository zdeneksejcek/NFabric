using System;

namespace NFabric.BoundedContext
{
    public class MessageDescriptorWithType : MessageDescriptor
    {
        public Type Type { get; private set; }

        public MessageDescriptorWithType(string messageType, string messageName, string messageBC, Type type) : base(messageType, messageName, messageBC)
        {
            Type = type;
        }
    }
}
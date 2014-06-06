using System;

namespace NFabric.BoundedContext
{
    [Serializable]
    public class MessageDescriptor
    {
        public string MessageType { get; private set; }
        public string MessageName { get; private set; }
        public string MessageBC { get; private set;}

        public MessageDescriptor(string messageType, string messageName, string messageBC) {
            MessageType = messageType;
            MessageName = messageName;
            MessageBC = messageBC;
        }
    }
}
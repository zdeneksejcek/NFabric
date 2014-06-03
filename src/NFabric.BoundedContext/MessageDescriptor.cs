using System;

namespace NFabric.BoundedContext
{
    [Serializable]
    public class MessageDescriptor
    {
        public string Type { get; private set; }
        public string MessageName { get; private set; }
        public string MessageBC { get; private set;}

        public MessageDescriptor(string type, string messageName, string messageBC) {
            Type = type;
            MessageName = messageName;
            MessageBC = messageBC;
        }
    }
}
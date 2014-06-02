using System;

namespace NFabric.Common.Messaging
{
    [Serializable]
    public class Message
    {
        public string Type { get; private set; }
        public string BoundedContext { get; private set; }
        public string Name { get; private set; }
        public string Body { get; private set;}

        public Message(string type, string boundedContext, string name, string body)
        {
            Type = type;
            BoundedContext = boundedContext;
            Name = name;
            Body = body;
        }
    }
}


using System;

namespace NFabric.Common
{
    public class MessageName
    {
        public string Name { get; private set; }

        public MessageName(string name)
        {
            Name = name;
        }
    }
}


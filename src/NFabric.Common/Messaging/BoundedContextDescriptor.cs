using System;
using System.Collections.Generic;

namespace NFabric.Common.Messaging
{
    public class BoundedContextDescriptor
    {
        public string Name { get; private set; }
        private IList<string> _handledCommands = null;
        public IList<string> HandledCommands { get { return _handledCommands; }}

        private IList<string> _handledEvents = null;
        public IList<string> HandledEvents { get { return _handledEvents; }}

        public BoundedContextDescriptor(string name, IList<string> handledCommands, IList<string> handledEvents)
        {
            Name = name;
            _handledEvents = handledEvents;
            _handledCommands = handledCommands;
        }
    }
}


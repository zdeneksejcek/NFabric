using System;
using System.Linq;
using NFabric.Common.Messaging;
using System.Reflection;
using System.Collections.Generic;

namespace NFabric.Common
{
    public class MessageDispatcher
    {
        IServiceBus _bus;
        //MessageSerializer _serializer = new MessageSerializer();

        public MessageDispatcher(IServiceBus bus)
        {
            _bus = bus;
        }

        public void DispatchMessage(UncommitedMessage message) {
            _bus.CreateMessagePublisher().Publish(message);
        }
    }
}
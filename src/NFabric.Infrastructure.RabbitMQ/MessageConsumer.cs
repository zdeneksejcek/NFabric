﻿using System;
using NFabric.Common.Messaging;
using System.Text;

namespace NFabric.Infrastructure.RabbitMQ
{
    public class MessageConsumer : IMessageConsumer
    {
        private EasyNetQ.IAdvancedBus _bus;

        internal MessageConsumer(EasyNetQ.IAdvancedBus bus)
        {
            _bus = bus;
        }

        public IDisposable Consume(string bcName, Action<Message> onMessage) {
            var queue = new EasyNetQ.Topology.Queue(bcName, false);

            return _bus.Consume<string>(queue,
                (EasyNetQ.IMessage<string> message, EasyNetQ.MessageReceivedInfo info) => Receive(message, info, onMessage));
        }

        private void Receive(EasyNetQ.IMessage<string> rabbitMessage, EasyNetQ.MessageReceivedInfo info, Action<Message> onMessage) {
            var msBCBytes = rabbitMessage.Properties.Headers["msBC"] as byte[];
            var msNameBytes = rabbitMessage.Properties.Headers["msName"] as byte[];
            var msTypeBytes = rabbitMessage.Properties.Headers["msType"] as byte[];

            string msName = Encoding.UTF8.GetString(msNameBytes);
            string msBC = Encoding.UTF8.GetString(msBCBytes);
            string msType = Encoding.UTF8.GetString(msTypeBytes);

            var message = new Message(msType, msBC, msName, rabbitMessage.Body);

            onMessage(message);
        }
    }
}
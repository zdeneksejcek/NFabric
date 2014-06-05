using System;
using NFabric.Common.Messaging;
using EasyNetQ.Topology;

namespace NFabric.Infrastructure.RabbitMQ
{
    public class MessagePublisher : IMessagePublisher
    {
        private EasyNetQ.IAdvancedBus _bus;

        internal MessagePublisher(EasyNetQ.IAdvancedBus bus)
        {
            _bus = bus;
        }

        public void Publish(params UncommitedMessage[] messages) {
            foreach (var m in messages)
            {
                switch (m.Type)
                {
                    case "event":
                        _bus.Publish(
                            new Exchange(m.Name),
                            string.Empty,
                            true,
                            false,
                            new NFabricMessage("event", m.Name, m.Body, m.BoundedContext)
                        );
                    break;
                    case "command":
                            _bus.Publish(
                                new Exchange(m.BoundedContext),
                                string.Empty,
                                true,
                                false,
                                new NFabricMessage("command", m.Name, m.Body, m.BoundedContext)
                            );
                    break;
                }
            }
        }
    }
}
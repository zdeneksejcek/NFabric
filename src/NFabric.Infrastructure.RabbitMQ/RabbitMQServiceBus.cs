using System;
using NFabric.Host.Messaging;

namespace NFabric.Infrastructure.RabbitMQ
{
    public class RabbitMQServiceBus : IServiceBus
    {
        private EasyNetQ.IAdvancedBus _bus;

        public RabbitMQServiceBus(string connectionString)
        {
            _bus = EasyNetQ.RabbitHutch.CreateBus(connectionString).Advanced;
        }

        public void Dispose()
        {
            _bus.Dispose();
        }

        #region IServiceBus implementation

        public void EnsureBoundedContext(BoundedContextDescriptor bc)
        {
            var bcQueue = _bus.QueueDeclare(bc.Name);
            var bcExchange = _bus.ExchangeDeclare(bc.Name, "fanout");
            _bus.Bind(bcExchange, bcQueue, string.Empty);

            foreach (var ev in bc.HandledEvents)
            {
                var eventExchange = _bus.ExchangeDeclare(ev, "fanout");

                _bus.Bind(eventExchange, bcQueue, string.Empty);
            }
        }

        public IMessagePublisher CreateMessagePublisher()
        {
            return new MessagePublisher(_bus);
        }

        public IMessageConsumer CreateMessageConsumer()
        {
            return new MessageConsumer();
        }

        #endregion
    }
}
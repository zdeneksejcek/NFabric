using System;
using NFabric.Host.Messaging;
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

        public void PublishCommand(CommandMessage command) {
            _bus.Publish(
                new Exchange(command.BoundedContext),
                string.Empty,
                true,
                true,
                new MyMessage()
            );
        }

        public void PublishEvent(params object[] @events) {

        }

        public class MyMessage : EasyNetQ.IMessage<string> {
            #region IMessage implementation

            public EasyNetQ.MessageProperties Properties
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public string Body
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            #endregion


        }

    }
}
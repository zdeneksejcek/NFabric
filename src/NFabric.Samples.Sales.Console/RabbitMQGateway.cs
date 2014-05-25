using System;
using NFabric.Common;
using EasyNetQ;
using System.Threading.Tasks;

namespace NFabric.Samples.Sales.Console
{
    public class RabbitMQGateway : IMessageGateway
    {
        private IBus _bus;

        public RabbitMQGateway()
        {
            _bus = EasyNetQ.RabbitHutch.CreateBus("host=localhost");
        }

        public void SendMessage(MessageEnvelope message)
        {
            Parallel.For(0, 500000, (i) => {
                _bus.Send("nfabric", message);
            });
        }
    }
}
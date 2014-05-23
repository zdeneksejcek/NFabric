using System;
using NFabric.Common;
using System.Text;

namespace NFabric.Client
{
    public class CommandDispatcher : IDispachesCommand
    {
        private IMessageGateway _gateway;

        public CommandDispatcher(IMessageGateway gateway)
        {
            _gateway = gateway;
        }

        public void Dispatch(object command) {
            byte[] bytes = Encoding.UTF8.GetBytes("Hello World");
            _gateway.SendMessage(new MessageEnvelope(MessageType.Command, "default", bytes));
        }

        public void Dispatch(string commandName, object command) {

        }
    }
}
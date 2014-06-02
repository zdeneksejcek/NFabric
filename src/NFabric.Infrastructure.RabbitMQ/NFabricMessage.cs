using System;

namespace NFabric.Infrastructure.RabbitMQ
{
    public class NFabricMessage : EasyNetQ.IMessage<string> {
        private string _messageName;
        private string _bcName;
        private string _messageType;

        public EasyNetQ.MessageProperties Properties
        {
            get {
                var props = new EasyNetQ.MessageProperties();
                props.Headers.Add("msName", _messageName);
                props.Headers.Add("msBC", _bcName);
                props.Headers.Add("msType", _messageType);
                return props;
            }
        }

        public string Body
        {
            get;
            private set;
        }

        public NFabricMessage(string messageType, string messageName, string body, string bcName) {
            _messageType = messageType;
            _messageName = messageName;
            Body = body;
            _bcName = bcName;
        }

    }
}


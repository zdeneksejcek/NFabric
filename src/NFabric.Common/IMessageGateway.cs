using System;

namespace NFabric.Common
{
    public interface IMessageGateway
    {
        void SendMessage(MessageEnvelope message);
    }
}
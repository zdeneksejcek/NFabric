using System;

namespace NFabric.Common.Messaging
{
    public interface IMessagePublisher
    {
        void Publish(params UncommitedMessage[] @messages);
    }
}


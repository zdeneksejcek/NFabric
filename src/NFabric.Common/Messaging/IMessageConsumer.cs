using System;

namespace NFabric.Common.Messaging
{
    public interface IMessageConsumer
    {
        IDisposable Consume(string bcName, Action<Message> onMessage);
    }
}


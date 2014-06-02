using System;

namespace NFabric.Common
{
    public class MessageSerializer
    {
        public MessageSerializer()
        {
        }

        public string Serialize(object message) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(message);
        }

        public object Deserialize(string message) {
            return null;
        }

    }
}


using System;

namespace NFabric.BoundedContext
{
    public class Serializer
    {
        public static string Serialize(object obj) {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static object Deserialize(string json, Type type) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(json, type);
        }

    }
}
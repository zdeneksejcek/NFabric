namespace NFabric.BoundedContext
{
    public class MessageName
    {
        public string BoundedContext { get; private set; }
        public string Name { get; private set; }

        public MessageName(string bc, string name)
        {
            BoundedContext = bc;
            Name = name;
        }
    }
}

namespace NFabric.Host.Arguments
{
    public class Arguments
    {
        public string BCFileName { get; private set; }
        
        public Arguments(string[] args)
        {
            BCFileName = args[0];
        }

    }
}

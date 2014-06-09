namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderCommentsChanged
    {
        public string Comments { get; private set; }

        public SalesOrderCommentsChanged(string comments)
        {
            Comments = comments;
        }
    }
}

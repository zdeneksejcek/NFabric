using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderCommentsChanged : IAggregateEvent
    {
        public string Comments { get; private set; }

        public SalesOrderCommentsChanged(string comments)
        {
            Comments = comments;
        }
    }
}
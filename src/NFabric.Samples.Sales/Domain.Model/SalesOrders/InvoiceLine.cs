using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class InvoiceLine : EntityWithES
    {
        public InvoiceLine(AggregateEvents events) : base(events)
        {
        }
    }
}
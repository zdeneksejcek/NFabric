using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.Customers
{
    public class Customer : AggregateWithES
    {
        public Customer()
        {
        }

        protected override void InitializeEventHandlers()
        {
            
        }
    }
}


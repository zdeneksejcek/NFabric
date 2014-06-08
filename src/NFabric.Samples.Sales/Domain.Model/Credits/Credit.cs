using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class Credit : AggregateWithES
    {
        public CreditLines Lines { get; private set; }

        public Credit()
        {
        }

        protected override void InitializeEventHandlers()
        {

        }
    }
}


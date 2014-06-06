using System;
using System.Collections.Generic;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Snapshot;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class SalesOrder : AggregateWithES
	{
		private CustomerId Customer { get; set; }

        public SalesOrderLines Lines { get; private set; }

        public Invoices Invoices { get; private set; }

        public Shipments Shipments { get; private set; }

        public SalesOrder(CustomerId customer, WarehouseId warehouse)
		{
            Id = Guid.NewGuid();
            Init();
            Events.Update(
                new SalesOrderCreated(Id, customer.Id));
		}

        public SalesOrder(Guid id, IEnumerable<SequencedEvent> events) {
            Id = id;
            Init();

            base.Events.UpdateCommited(events);
        }

        public SalesOrder(SalesOrderSnapshot snapshot, IEnumerable<SequencedEvent> events) {
            Init();

            base.Events.UpdateCommited(events);
        }

        private void Init() {
            InitHandlers();

            Lines = new SalesOrderLines(base.Events, () => base.Id);
            Invoices = new Invoices(base.Events, () => base.Id);
            Shipments = new Shipments(base.Events, () => base.Id);
        }

        #region event handlers

        private void InitHandlers() {
            base.Events.Handles<SalesOrderCreated>(this.Apply);
        }

		private void Apply(SalesOrderCreated @event)
        {
            Id = @event.SalesOrderId;
            Customer = new CustomerId(@event.Customer);
        }

        #endregion
	}
}
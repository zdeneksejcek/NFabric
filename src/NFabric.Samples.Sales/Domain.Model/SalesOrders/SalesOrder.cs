using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;
using OpenDDD;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Events;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;

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
                new SalesOrderCreated(Id, customer));
		}

        public SalesOrder(Guid id, IEnumerable<Event> events) {
            Id = id;
            Init();

            base.Events.UpdateCommited(events);
        }

        private void Init() {
            InitHandlers();

            Lines = new SalesOrderLines(Id, base.Events);
            Invoices = new Invoices(Id, base.Events);
            Shipments = new Shipments(Id, base.Events);
        }

        #region event handlers

        private void InitHandlers() {
            base.Events.Handles<SalesOrderCreated>(Id,this.Apply);
        }

		private void Apply(SalesOrderCreated @event)
        {
            Customer = @event.Customer;
		}

        #endregion
	}
}
using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;
using OpenDDD;
using NFabric.Samples.Sales.Domain.Model.SalesOrder.Events;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder
{
	public class SalesOrder : AggregateWithES
	{
		private CustomerId Customer { get; set; }

        private SalesOrderLines Lines { get; set; }

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
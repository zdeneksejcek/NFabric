using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;
using OpenDDD;
using NFabric.Samples.Sales.Domain.Model.SalesOrder.Events;
using System.Diagnostics;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder
{
    [DebuggerDisplay("{Id.Id}")]
	public class SalesOrder : AggregateWithES
	{
        private SalesOrderId Id { get; set;}
		private CustomerId Customer { get; set; }

        private SalesOrder() {
            Handles<SalesOrderCreated>((e) => this.Apply(e));
        }

        public SalesOrder(CustomerId customer) : this()
		{
            Update(
                new SalesOrderCreated(
                    new SalesOrderId(),
                    customer
            ));
		}

        public SalesOrder(IEnumerable<Event> events) : this() {
            UpdateCommited(events);
        }

        public void AddLine(ProductId product, SalesOrderLineQuantity quantity) {
            Update(
                new SalesOrderLineAdded(product, quantity));
        }

        #region event handlers

		private void Apply(SalesOrderCreated @event)
        {
            Id = @event.Id;
            Customer = @event.Customer;
		}

        #endregion
	}
}
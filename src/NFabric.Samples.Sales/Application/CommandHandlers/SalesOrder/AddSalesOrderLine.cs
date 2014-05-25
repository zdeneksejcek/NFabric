﻿using System;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class AddSalesOrderLine
    {
        public Guid SalesOrder { get; private set; }
        public Guid Product { get; private set; }
        public int Quantity { get; private set; }

        public AddSalesOrderLine(Guid salesOrder, Guid product, int quantity)
        {
            SalesOrder = salesOrder;
            Product = product;
            Quantity = quantity;
        }
    }
}
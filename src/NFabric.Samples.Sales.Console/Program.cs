﻿using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrder;

namespace NFabric.Samples.Sales.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SalesOrder so = new SalesOrder(new CustomerId(Guid.NewGuid()));

            System.Console.WriteLine("Hello World!");
        }
    }
}
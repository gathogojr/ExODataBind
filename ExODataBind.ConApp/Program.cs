using System;
using Default;
using ExODataBind.Models;

namespace ExODataBind.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 1,
                Amount = 13M,
            };

            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1"
            };

            var serviceUri = new Uri("http://localhost:33435/odata");
            var dataServiceContextInstance = new Container(serviceUri);

            dataServiceContextInstance.AddToCustomers(customer);
            dataServiceContextInstance.AddToOrders(order);
            dataServiceContextInstance.SetLink(order, "Customer", customer);

            dataServiceContextInstance.SaveChanges();
        }
    }
}

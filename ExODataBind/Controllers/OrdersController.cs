using System;
using System.Collections.Generic;
using System.Linq;
using ExODataBind.Models;
using ExODataBind.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ExODataBind.Controllers
{
    public class OrdersController : ODataController
    {
        private static IList<Order> orders = new List<Order>(
            Enumerable.Range(1, 3).Select(idx => new Order
            {
                Id = TokenGenerator.GenerateRandomId(),
                Customer = new Customer { Id = TokenGenerator.GenerateRandomId(), Name = $"Customer {(idx % 2 == 0 ? 1 : 2)}" },
                Amount = new Random().Next(7, 13)
            }));

        [EnableQuery]
        public IQueryable<Order> Get()
        {
            return orders.AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Order> Get([FromODataUri] int key)
        {
            return SingleResult.Create<Order>(orders.Where(d => d.Equals(key)).AsQueryable());
        }

        public ActionResult Post([FromBody] Order order)
        {
            order.Id = TokenGenerator.GenerateRandomId();

            return Created(new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{order.Id}"), order);
        }

        public ActionResult Put([FromODataUri] int key, [FromBody] Order order)
        {
            return Accepted();
        }
    }
}

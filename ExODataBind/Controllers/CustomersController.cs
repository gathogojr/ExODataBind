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
    public class CustomersController : ODataController
    {
        private static IList<Customer> customers = new List<Customer>(
            Enumerable.Range(1, 2).Select(idx => new Customer { Id = TokenGenerator.GenerateRandomId(), Name = $"Customer {idx}" }));

        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return customers.AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Customer> Get([FromODataUri] int key)
        {
            return SingleResult.Create<Customer>(customers.Where(d => d.Equals(key)).AsQueryable());
        }

        public ActionResult Post([FromBody] Customer customer)
        {
            customer.Id = TokenGenerator.GenerateRandomId();

            return Created(new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{customer.Id}"), customer);
        }

        public ActionResult Put([FromODataUri] int key, [FromBody] Customer customer)
        {
            return Accepted();
        }
    }
}

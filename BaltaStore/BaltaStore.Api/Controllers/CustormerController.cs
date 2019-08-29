using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustormerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("José", "LeLé");
            var document = new Document("437181155363");
            var email = new Email("lele@email.com");
            var customer = new Customer(name, document, email, "11998765432");

            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("José", "LeLé");
            var document = new Document("437181155363");
            var email = new Email("lele@email.com");
            var customer = new Customer(name, document, email, "11998765432");
            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("José", "LeLé");
            var document = new Document("437181155363");
            var email = new Email("lele@email.com");
            var customer = new Customer(name, document, email, "11998765432");
            var order = new Order(customer);

            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);

            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);
            var orders = new List<Order>();
            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email );
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email );
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete([FromBody] Customer customer)
        {
            return new { message = "Cliente removido com sucesso" };
        }        
    }
}
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("José", "Lelé");
            var document = new Document("32065432180");
            var email = new Email("lele@gmail.com");
            var c = new Customer(name, document, email, "9898989898");

            var mouse = new Product("Mouse", "Rato", "Image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "Image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "Image.png", 359.90M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "Image.png", 559.90M, 10);
            
            var order = new Order(c);            
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(cadeira, 5));
            //order.AddItem(new OrderItem(impressora, 5));

            // Realizei o pedido
            order.Place();

            var valid = order.Valid;

            // Simular pagamento
            order.Pay();

            // Simular Envio
            order.Ship();

            // Simular o cancelamento
            order.Cancel();
            
        }
    }
}

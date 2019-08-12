using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("José", "LeLé");
            var document = new Document("437181155363");
            var email = new Email("lele@email.com");
            _customer = new Customer(name, document, email, "11998765432");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "Teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "Cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrder_WhenValid()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        // ao criar o pedido o status deve ser created
        [TestMethod]        
        public void StatusShouldBeCreated_WhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // ao adicionar um novo item, a quantidade de itens deve mudar 
        [TestMethod]        
        public void ShouldReturnTwo_WhenAddedTwoValidItens()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // ao adiconar um novo item, deve subtrair a quantidade do produto
        [TestMethod]        
        public void ShouldReturnFive_WhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // ao confirmar pedido, deve gerar um número
        [TestMethod]        
        public void ShouldReturnANumber_WhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // ao pagar um pedido o status deve ser PAGO
        [TestMethod]        
        public void ShouldReturnPaind_WhenOrderPaid()
        {            
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        
        // dados 10 protudos devem haver duas entregas
        [TestMethod]        
        public void ShouldReturnTwoShippings_WhenPurchaseTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);                        
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);                                                                        
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // ao cancelar o pedido o status deve ser CANCELADO
        [TestMethod]        
        public void StatusShouldBeCanceled_WhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // ao cancelar o pedido deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippings_WhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);                        
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);                                                                        
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
    
}
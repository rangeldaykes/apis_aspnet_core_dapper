using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomer_WhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName =  "José";
            command.LastName =  "LeLé";
            command.Document =  "28659170377";
            command.Email =  "lele@email.com";
            command.Phone =  "4199999999";

            Assert.AreEqual(true, command.Valid);    

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}

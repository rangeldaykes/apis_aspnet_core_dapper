using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidate_WhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName =  "José";
            command.LastName =  "LeLé";
            command.Document =  "28659170377";
            command.Email =  "lele@email.com";
            command.Phone =  "4199999999";

            Assert.AreEqual(true, command.Valid);            
        }   
    }
}

using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "José",
                "Lelé",
                "32065432180",
                "lele@gmail.com",
                "9898989898",
                "Rua vai e vem, 123"
            );            

            var order = new Order(c);
            //order.AddItem()

        }
    }
}

using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTests // <-- não há necessidade de testar pq o flunt já foi testado
    {
        [TestMethod]
        public void ShoulReturnNotification_WhenNameIsNotValid()
        {
            var name = new Name("", "lelé");
            Assert.AreEqual(false, name.Valid);
            Assert.AreEqual(1, name.Notifications.Count);
            Assert.IsTrue(name.Notifications.Count > 0);
        }
     
    }
}

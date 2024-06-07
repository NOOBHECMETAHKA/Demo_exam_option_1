using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOOTehnical;

namespace OOOTehnicalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void succesFullAuth()
        {
            DataBaseClass dataBaseClass = new DataBaseClass();
            Assert.AreEqual(dataBaseClass.checkAuth("CAXAP", "123"), true);
        }
    }
}

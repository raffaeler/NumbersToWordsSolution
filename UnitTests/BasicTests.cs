using Microsoft.VisualStudio.TestTools.UnitTesting;

using NumbersToWordsSolution;

namespace UnitTests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Tests01()
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("it-IT");

            Assert.AreEqual(122460.6m.AsString(), "centoventiduemilaquattrocentosessanta/60");
            Assert.AreEqual(22460.6m.AsString(), "ventiduemilaquattrocentosessanta/60");
            Assert.AreEqual(3240.5m.AsString(), "tremiladuecentoquaranta/50");
            Assert.AreEqual(240.5m.AsString(), "duecentoquaranta/50");
            Assert.AreEqual(400m.AsString(), "quattrocento/00");
            Assert.AreEqual(400m.AsString(true), "quattrocento");
        }

    }
}

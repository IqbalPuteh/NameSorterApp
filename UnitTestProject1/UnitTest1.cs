using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ExpectedPeoClassResult = "Iqbal Puteh";
            People Peo = new People("Puteh", "Iqbal" + " ");
            Assert.AreEqual(ExpectedPeoClassResult, Peo.ToString());    


        }
    }
}

using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseRomerTall;


namespace ParseRomerTallTest
{
    [TestClass]
    public class UnitTest1
    {
        private ParseRomer romer = new ParseRomer();

        [TestMethod]
        public void TestMoreThan3()
        {
            Assert.AreNotEqual(romer.Parse("IIII"),4);
        }

        [TestMethod]
        public void TestRomerTall()
        {   
            Assert.AreEqual(romer.Parse(5), "V");
        }

        [TestMethod]
        public void TestFlereRomerTall()
        {
            Assert.AreEqual(romer.Parse(1999),"MCMXCIX");
        }

        [TestMethod]
        public void TestAll()
        {
            Assert.AreEqual(romer.Parse("V"),5);
        }

        [TestMethod]
        public void TestHard()
        {
            Assert.AreEqual(romer.Parse("MCMXCIX"),1999);
        }

        [TestMethod]
        public void TestEverything()
        {
            for(int i = 0;i<=3999;i++)
            {
                var romerRes = romer.Parse(i);
                Debug.WriteLine(string.Format("i={0},Roman={1}",i,romerRes));
                Assert.AreEqual(i,romer.Parse(romerRes));
            }
        }
    }


    
}

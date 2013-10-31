using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestHello
    {
        [TestMethod]
        public void TestMethodHello1()
        {
            string helloName = Hello.HelloPerson("Simo");
            Assert.AreEqual("Hello, Simo!", helloName);
        }

        [TestMethod]
        public void TestMethodHello2()
        {
            string helloName = Hello.HelloPerson("Ivan");
            Assert.AreEqual("Hello, Ivan!", helloName);
        }

        [TestMethod]
        public void TestMethodHello3()
        {
            string helloName = Hello.HelloPerson("");
            Assert.AreEqual("", helloName);
        }
    }
}

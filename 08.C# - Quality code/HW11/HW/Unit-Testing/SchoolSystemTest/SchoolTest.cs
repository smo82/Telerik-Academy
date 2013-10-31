namespace SchoolSystemTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestSchoolCreation()
        {
            School newSchool = new School("Telerik");
            string schoolName = newSchool.Name;

            Assert.AreEqual("Telerik", schoolName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] 
        public void TestSchoolCreationNull()
        {
            School newSchool = new School(null);
        }
    }
}

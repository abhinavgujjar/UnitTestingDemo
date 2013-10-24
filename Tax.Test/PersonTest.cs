using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tax.Entities;

namespace Tax.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Person_Age_Test_For_Zero()
        {
            Person person = new Person(DateTime.Now);
            Assert.AreEqual(0, person.Age);
        }

        [TestMethod]
        public void Person_Age_Test_For_Regular()
        {
            Person person = new Person(DateTime.Now.AddYears(-15));
            Assert.AreEqual(15, person.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Person_Age_Test_For_Invalid_DOB()
        {
            Person person = new Person(DateTime.Now.AddYears(1));
            
        }
    }
}

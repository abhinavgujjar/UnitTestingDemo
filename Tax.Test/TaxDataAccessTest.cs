using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tax.Entities;
using Tax.DataAccess;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Tax.Test
{
    [TestClass]
    public class TaxDataAccessTest
    {
        [TestMethod]
        public void TestOnlyFemales()
        {
            var mock = new Mock<TaxDbContext>();
            Mock.Setup<DbSet<SlabRate>>(foo => foo.SlabRates).Returns(
                new DbSet<SlabRate>() { new SlabRate() });

            //Person person = new Person(DateTime.Now);
            Assert.AreEqual(0, person.Age);
        }

        [TestMethod]
        public void TestOnlyMales()
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

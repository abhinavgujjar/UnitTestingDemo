using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tax.Entities;
using Tax.Business;
using Moq;
using Tax.DataAccess;
using System.Collections.Generic;

namespace Tax.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Sad_test()
        {
            var mock = new Mock<ITaxDataAccess>();
            mock.Setup(foo => foo.GetSlabRates(true)).Returns(
                new List<SlabRate>()
                {
                    new SlabRate(){
                         StartRange = 0.0M,
                         EndRange = 200000.0M,
                         Rate = 10.0M
                    }
                });

            IncomeTaxCalculator calc = new IncomeTaxCalculator(mock.Object);

            var tax = calc.CalculateTax(new Person()
            {
                isFemale = true,
                Income = 100000.0M,
                DateOfBirth = DateTime.Now.AddYears(-30)
            });

            Assert.AreEqual(10000.0M, tax);

        }

        [TestMethod]
        public void othertest()
        {
            var mock = new Mock<ITaxDataAccess>();
            IncomeTaxCalculator calc = new IncomeTaxCalculator(mock.Object);

             calc.CalculateTax(new Person());
             mock.Verify(foo => foo.GetSlabRates(It.IsAny<bool>()), Times.Exactly(2));


        }


    }
}

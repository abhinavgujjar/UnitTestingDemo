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
        public void Sad_test_for_no_slabs()
        {
            //var mock = new Mock<ITaxDataAccess>();

            //mock.Setup(foo => foo.GetSlabRates(It.IsAny<bool>())).Returns(
            //    (List<SlabRate>)null
            //    );

            //IncomeTaxCalculator calc = new IncomeTaxCalculator(mock.Object);

            //var tax = calc.CalculateTax(new Person()
            //{
            //    isFemale = true,
            //    Income = 100000.0M,
            //    DateOfBirth = DateTime.Now.AddYears(-30)
            //});

            //Assert.AreEqual(0, tax);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Woman_35_40000()
        {
            var mock = new Mock<ITaxDataAccess>();

            mock.Setup(foo => foo.GetSlabRates(true)).Returns(
                new List<SlabRate>()
                {
                    new SlabRate()
                    {
                         StartRange = 0.0M,
                         EndRange = 500000.0M,
                         Rate = 15.0M,
                         IsFemale = false
                    }
                });

            IncomeTaxCalculator calc = new IncomeTaxCalculator(mock.Object);

            var tax = calc.CalculateTax(new Person()
            {
                isFemale = true,
                Income = 700000.0M,
                DateOfBirth = DateTime.Now.AddYears(-30)
            });

        }

        [TestMethod]
        public void company_tax_effeciency()
        {
            var mock = new Mock<ITaxDataAccess>();

            mock.Setup(foo => foo.GetPeople()).Returns(
                new List<Person>()
                {
                    new Person(){
                         isFemale = true,
                Income = 700000.0M,
                DateOfBirth = DateTime.Now.AddYears(-30)
                    },
                    new Person(){
                         isFemale = true,
                Income = 90000.0M,
                DateOfBirth = DateTime.Now.AddYears(-30)
                    },

                });

            mock.Setup(foo => foo.GetSlabRates(It.IsAny<bool>())).Returns(
                            new List<SlabRate>()
            );


            IncomeTaxCalculator calculator = new IncomeTaxCalculator(mock.Object);

            calculator.CalculateCompanyTax();

            mock.Verify(foo => foo.GetSlabRates(true), Times.Exactly(1));
            mock.Verify(foo => foo.GetSlabRates(false), Times.Exactly(0));

        }


        //[TestMethod]
        //public void othertest()
        //{
        //    var mock = new Mock<ITaxDataAccess>();
        //    IncomeTaxCalculator calc = new IncomeTaxCalculator(mock.Object);

        //    calc.CalculateTax(new Person());
        //    mock.Verify(foo => foo.GetSlabRates(It.IsAny<bool>()), Times.Exactly(2));


        //}


    }
}

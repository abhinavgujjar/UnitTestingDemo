using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.DataAccess;
using Tax.Entities;

namespace Tax.Business
{
    public class IncomeTaxCalculator
    {
        private List<SlabRate> _femaleSlabRates;
        private List<SlabRate> _maleSlabRates;

        public SeniorCitizenRebate Rebate { get; set; }

        ITaxDataAccess _dataAccess;
        public ILogger Logger  { get; set; }

        private List<SlabRate> getMaleSlabRates()
        {
            if (_maleSlabRates == null)
            {
                _maleSlabRates = _dataAccess.GetSlabRates(false);
            }

            return _maleSlabRates;
        }
        
        public IncomeTaxCalculator(ITaxDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _femaleSlabRates = _dataAccess.GetSlabRates(true);

        }

        public decimal CalculateTax(Person target)
        {
          
            var tax = 0.0M;

            if (target.isFemale)
            {

                tax = calcFromSlabs(target, tax, _femaleSlabRates);
            }
            else
            {
                var slabRates = getMaleSlabRates();
                tax = calcFromSlabs(target, tax, slabRates);
            }

            if ( Rebate !=null &&  target.Age > Rebate.AgeLimit)
            {
                tax = tax - (tax * Rebate.Rebate / 100);
            }

            return tax;
        }

        private decimal calcFromSlabs(Person target, decimal tax, List<SlabRate> applicableSlabs)
        {
            foreach (var slab in applicableSlabs)
            {
                if (slab.IsFemale != target.isFemale)
                    throw new InvalidOperationException();

                if (target.Income > slab.EndRange)
                {
                    tax = tax + ((slab.EndRange - slab.StartRange) * slab.Rate / 100);
                }
                else if (target.Income >= slab.StartRange && target.Income < slab.EndRange)
                {
                    tax = tax + ((target.Income - slab.StartRange) * slab.Rate / 100);
                }
            }
            return tax;
        }

        public decimal CalculateCompanyTax()
        {
            decimal tax = 0.0M;

            var people = _dataAccess.GetPeople();

            foreach (var person in people)
            {
                tax = tax + CalculateTax(person);
            }

            return tax;
        }

        public decimal CalculateTotalIncome()
        {
            throw new NotImplementedException();
        }
    }
}

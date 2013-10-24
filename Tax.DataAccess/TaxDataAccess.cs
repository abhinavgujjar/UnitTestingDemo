using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.Entities;

namespace Tax.DataAccess
{
    public class TaxDataAccess : ITaxDataAccess
    {
        public List<SlabRate> GetSlabRates(bool isFemale)
        {
            var db = new TaxDbContext();
            var rates = db.SlabRates.Where(s => s.IsFemale == isFemale);
            return rates.ToList();
        }

        public List<Person> GetPeople()
        {
            var db = new TaxDbContext();
            var people = db.People;
            return people.ToList();
        }
    }
}

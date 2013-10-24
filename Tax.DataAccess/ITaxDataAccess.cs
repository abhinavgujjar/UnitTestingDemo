using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.Entities;

namespace Tax.DataAccess
{
    public interface ITaxDataAccess
    {
        List<SlabRate> GetSlabRates(bool isFemale);

        List<Person> GetPeople(); 
    }
}

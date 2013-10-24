using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tax.Entities;

namespace Tax.DataAccess
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext()
            
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<SlabRate> SlabRates { get; set; }
    }
}

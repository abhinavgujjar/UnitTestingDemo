using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Entities
{
    public class SeniorCitizenRebate
    {
        public int AgeLimit { get; set; }
        public decimal Rebate { get; set; }
    }

}

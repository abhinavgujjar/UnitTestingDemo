using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Entities
{
    public class SlabRate
    {
        public int Id { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }
        public decimal Rate { get; set; }
        public bool IsFemale { get; set; }
    }
}

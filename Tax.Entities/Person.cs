using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Person()
        {
        }


        public Person(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException();
            }

            DateOfBirth = dateOfBirth;
        }

        public int Age
        {
            get { return (DateTime.Now.Year - DateOfBirth.Year); }
        }

        public bool isFemale { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Income { get; set; }
    }
}

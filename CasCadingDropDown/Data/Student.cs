
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasCadingDropDown.Data
{
    public class Student
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }

        public string FullName { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
    }
}

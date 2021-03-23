using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasCadingDropDown.Data
{
    public class State
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateName { get; set; }
        public Country Country { get; set; }
        public List<City> City { get; set; }
        public List<Student> Student { get; set; }

    }
}

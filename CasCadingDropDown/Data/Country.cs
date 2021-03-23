using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasCadingDropDown.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public List<State> State { get; set; }
        public List<Student> Student { get; set; }

    }
}

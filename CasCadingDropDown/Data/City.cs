using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasCadingDropDown.Data
{
    public class City
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }


        public List<Student> Student { get; set; }
    }
}

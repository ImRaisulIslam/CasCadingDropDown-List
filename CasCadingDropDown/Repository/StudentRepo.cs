using CasCadingDropDown.Data;
using CasCadingDropDown.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasCadingDropDown.Repository
{
    public class StudentRepo
    {
        private readonly ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StudentDetailViewModel> StudentInfo()
        {

            var students = _context.Student.Select(student => new StudentDetailViewModel
            {
                Name = student.FullName,
                CityName = student.State.StateName,
                CountryName = student.Country.CountryName,

            }).ToList();

            return students;
        }
    }
}

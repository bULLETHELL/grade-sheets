using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grade_sheets
{
    public class Student
    {
        public string nme; // name property
        public List<Grade> grds; // grades list property
        public string schlCls; // school class property

        public Student(string name, List<Grade> grades, string schoolClass) // constructor for student object takes name, grades and schoolclass as properties
        {
            nme = name; // set the name property
            grds = grades; // set the grade property
            schlCls = schoolClass; // set the school class property
        }
    }
}

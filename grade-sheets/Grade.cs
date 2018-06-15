using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grade_sheets
{
    public class Grade
    {
        public string sbjct; // subject property
        public float grd; // grade property
        
        public Grade(string subject, float grade) // Constructor for Grade object takes subject and grade as inputs
        {
            sbjct = subject; // set the subject property
            grd = grade; // set the grade property
        }
    }
}


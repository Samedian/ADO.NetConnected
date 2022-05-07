using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities
{
    public class Student
    {
        public Student()
        {
                
        }
        public Student(string StudentName,double StudentMarks)
        {
            this.StudentName = StudentName;
            this.StudentMarks = StudentMarks;
        }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public double StudentMarks { get; set; }

        public char StudentGrade { get; set; }

    }
}

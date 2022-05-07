using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class StudentBussinessLayer
    {
        /// <summary>
        /// This function calc the grade of student based on marks stored by user
        /// and send data to data access layer
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public string AddStudent(Student student)
        {
            if (student.StudentMarks > 75)
                student.StudentGrade = 'A';
            else
                if (student.StudentMarks > 60)
                student.StudentGrade = 'B';
            else
                if (student.StudentMarks > 45)
                student.StudentGrade = 'C';
            else
                if (student.StudentMarks > 30)
                student.StudentGrade = 'D';
            else
                student.StudentGrade = 'E';

            StudentDataAccessLayer dataAccessLayer = new StudentDataAccessLayer();  //data access layer object

            string msg = dataAccessLayer.AddToDataBase(student);        //calls data access layer function

            return msg;

        }

        /// <summary>
        /// This function is used to pass value (id) and based on it fetch record by data access layer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Student> DisplayById(int id)
        {
            StudentDataAccessLayer dataAccessLayer = new StudentDataAccessLayer();  //data access layer object

            List<Student> student = dataAccessLayer.FetchById(id);      //calls data access layer function

            return student;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteById(int id)
        {
            StudentDataAccessLayer dataAccessLayer = new StudentDataAccessLayer();  //data access layer object
            string msg = dataAccessLayer.DeleteById(id);
            return msg;
        }

        /// <summary>
        ///  this function fetch all the records of students type from data acess layer 
        /// </summary>
        /// <returns></returns>

        public List<Student> Display()
        {
            StudentDataAccessLayer dataAccessLayer = new StudentDataAccessLayer();  //data access layer object
            List<Student> student = dataAccessLayer.FetchAll();
            return student;

        }
    }
}

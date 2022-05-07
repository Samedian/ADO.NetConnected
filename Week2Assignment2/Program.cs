using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;

namespace Week2Assignment2
{
    class Program
    {
        /// <summary>
        /// This is Main function Execution starts from here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();        //program object to call non static functions

            char ch;                                //It store value to check if user want to run more time or not
            int choice;
            do
            {
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Display based on id");
                Console.WriteLine("3.Display All the students");
                Console.WriteLine("4.Delete based on id");
                choice = Input.PositiveInteger();

                switch(choice)
                {
                    case 1:
                        string str= program.AddStudent();
                        Console.WriteLine(str);
                        break;

                    case 2:
                        str = program.DisplayById();
                        Console.WriteLine(str);
                        break;

                    case 3:
                        str = program.Display();
                        Console.WriteLine(str);
                        break;

                    case 4:
                        str = program.DeleteById();
                        Console.WriteLine(str);
                        break;


                }
                Console.WriteLine("Press Y or y to continue");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'Y' || ch == 'y');
        }

        /// <summary>
        /// This is used to display all the records present in the database
        /// 
        /// </summary>
        /// <returns></returns>
        private string Display()
        {
            StudentBussinessLayer bussinessLayer = new StudentBussinessLayer();     //bussiness layer object
            List<Student> students = bussinessLayer.Display();                      //calls bussiness layer function

            foreach (Student data in students)
            {
                Console.WriteLine("Student Id    :" + data.StudentId);
                Console.WriteLine("Student Name  :" + data.StudentName);
                Console.WriteLine("Student Marks :" + data.StudentMarks);
                Console.WriteLine("Student Grade :" + data.StudentGrade);

            }

            return "Query Executed";

        }

        /// <summary>
        /// This function asked for the id for which the details to be deleted
        /// and send the data to bussiness layer
        /// </summary>
        /// <returns></returns>
        private  string DeleteById()
        {
            Console.WriteLine("Enter ID");
            int id = Input.PositiveInteger();       // student id

            StudentBussinessLayer bussinessLayer = new StudentBussinessLayer(); //bussiness layer object

            string msg = bussinessLayer.DeleteById(id); //calls bussiness layer function

            return msg;
        }

        /// <summary>
        /// This Function is used to display the student details based on id entered by user,
        /// the data is send to bussiness layer
        /// </summary>
        /// <returns></returns>
        private  string DisplayById()
        {
            Console.WriteLine("Enter Id");
            int id = Input.PositiveInteger();       //student id

            StudentBussinessLayer bussinessLayer = new StudentBussinessLayer(); //bussiness layer object
            List<Student> students = bussinessLayer.DisplayById(id);        //calls bussiness layer func

            foreach (Student data in students)
            {
                Console.WriteLine("Student Id    :"+data.StudentId);
                Console.WriteLine("Student Name  :" + data.StudentName);
                Console.WriteLine("Student Marks :"+data.StudentMarks);
                Console.WriteLine("Student Grade :" + data.StudentGrade);

            }

            return "Query Executed";
        }


        /// <summary>
        /// This Function is used to add the student details 
        /// by user and send it to bussiness layer &
        /// if it successfully executed then it return success message otherwise error 
        /// </summary>
        /// <returns></returns>
        private string AddStudent()
        {
            string name;
            double marks;

            Console.WriteLine("Enter Name :");
            name = Input.StringInput();         //Student Name which contain only alphabets

            Console.WriteLine("Enter Marks :");
            marks = Input.PositiveDouble();     //Marks which is not negative


            Student student = new Student(name, marks);     //student constructor calls
            StudentBussinessLayer bussinessLayer = new StudentBussinessLayer(); //Bussiness Layer Object

            string msg = bussinessLayer.AddStudent(student);    //calls bussiness layer function

            return msg;
        }
    }
}

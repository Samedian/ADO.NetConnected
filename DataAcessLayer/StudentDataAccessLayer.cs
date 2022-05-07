using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Configuration;

namespace DataAcessLayer
{
    public class StudentDataAccessLayer
    {
        /// <summary>
        /// it connects to sql server and fetch particular id details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Student> FetchById(int id)
        {

            List<Student> studentList = new List<Student>();    //list
            Student student = new Student();    //student entity object

            try
            {
                string ConString = @"Data Source=DESKTOP-HLM777P; Initial Catalog =Samarth ;Integrated Security = true;";   //connection string

                SqlConnection sqlConnection = new SqlConnection(ConString);
                sqlConnection.Open();

                string query = @"SELECT * FROM STUDENTS WHERE StudentId =" + id + ";";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    student.StudentId = Convert.ToInt32(reader[0]);
                    student.StudentName = reader[1].ToString();
                    student.StudentMarks =Convert.ToDouble(reader[2]);
                    student.StudentGrade = Convert.ToChar(reader[3]);

                    studentList.Add(student);

                }

                sqlConnection.Close();


            }catch(Exception)
            {
                
            }
            return studentList;

        }

        /// <summary>
        /// this function fetch all details of student database
        /// </summary>
        /// <returns></returns>
        public  List<Student> FetchAll()
        {
            
            List<Student> studentList = new List<Student>();
            

            try
            {
                string ConString = @"Data Source=DESKTOP-HLM777P; Initial Catalog =Samarth ;Integrated Security = true;";

                SqlConnection sqlConnection = new SqlConnection(ConString);
                sqlConnection.Open();

                string query = @"SELECT * FROM STUDENTS;";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = Convert.ToInt32(reader[0]);
                    student.StudentName = reader[1].ToString();
                    student.StudentMarks = Convert.ToDouble(reader[2]);
                    student.StudentGrade = Convert.ToChar(reader[3]);

                    studentList.Add(student);
                }

                sqlConnection.Close();

            }
            catch (Exception)
            {
                
            }

            return studentList;
        }


        public  string DeleteById(int id)
        {
  

            try
            {
                string ConString = @"Data Source=DESKTOP-HLM777P; Initial Catalog =Samarth ;Integrated Security = true;";

                SqlConnection sqlConnection = new SqlConnection(ConString);
                sqlConnection.Open();

                string query = @"Delete from STUDENTS where StudentId ="+id+";";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int row = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return "Query Executed Successfully";
            }
            catch (Exception exception)
            {
                return "Something Went Wrong !!\n"+exception;
            }

        }

        public  string AddToDataBase(Student student)
        {
            try
            {
                
                string ConString = @"Data Source=DESKTOP-HLM777P; Initial Catalog =Samarth ;Integrated Security = true;";

                SqlConnection sqlConnection = new SqlConnection(ConString);
                sqlConnection.Open();

                string query = @"Insert INTO STUDENTS Values('"+ student.StudentName + "'," + student.StudentMarks + ",'"
                    + student.StudentGrade + "');";


                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int row = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }catch(Exception exception)
            {
                return ("Some Error Occurs !!!\n" + exception);
            }

            
            return "Sucessfully Added One Row";
        }
    }
}

using ADO.NET_.NET_CORE.Models;
using ADO.NET_.NET_CORE.Models.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.NET_.NET_CORE.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> GetAllStudents()
        {
            //string connectionstring = @"Data Source=DESKTOP-JH5DU96;Initial Catalog=TestDb;Integrated Security=True";
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                //define command
                //best practice make stored procedure
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetAllStudents", conn))
                {
                    //connection open
                    //for using stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    //read data
                    SqlDataReader reader = cmd.ExecuteReader();
                    //is reader se read kro data ko
                    while (reader.Read())
                    {
                        //link object to reader
                        Student student = new Student();
                        student.StudentId = Convert.ToInt32(reader["StudentId"]);
                        student.FullName = reader["FullName"].ToString();
                        student.Email = reader["Email"].ToString();
                        student.Mobile = reader["Mobile"].ToString();
                        student.Notes = reader["Notes"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                //define command
                //best practice make stored procedure
                using (SqlCommand cmd = new SqlCommand("usp_StudentsUpdateStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    //read data
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);

                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                    cmd.Parameters.AddWithValue("@Notes", student.Notes);

                    cmd.ExecuteNonQuery();


                }
            }
        }

        //create
        // void because it returns nothing
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                //define command
                //best practice make stored procedure
                using (SqlCommand cmd = new SqlCommand("usp_StudentsAddStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    //read data
                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);

                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                    cmd.Parameters.AddWithValue("@Notes", student.Notes);

                    cmd.ExecuteNonQuery();


                }
            }

        }
        public Student GetStudentByStudentId(int studentId)
        {
            Student student = new Student();

            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                //define command
                //best practice make stored procedure
                using (SqlCommand cmd = new SqlCommand("usp_StudentsGetStudentById", conn))
                {
                    //connection open
                    //for using stored procedure
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    //read data
                    SqlDataReader reader = cmd.ExecuteReader();
                    //is reader se read kro data ko
                    reader.Read();
                    //link object to reader
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.FullName = reader["FullName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Notes = reader["Notes"].ToString();
                    student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                }

            }
            return student;

        }
        public void DeleteStudent(int studentId)
        {
            using (SqlConnection conn = new SqlConnection(AppSettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_StudentsDeleteStudent", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
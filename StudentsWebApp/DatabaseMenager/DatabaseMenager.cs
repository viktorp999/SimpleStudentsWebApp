using StudentsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsWebApp.DatabaseMenager
{
    public class DatabaseMenager
    {
        private string dbconnectionstring = "Data Source=VIKTOR-PC;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<StudentModel> FetchAllStudents()
        {
            List<StudentModel> returnstudent = new List<StudentModel>();
            using (SqlConnection dbconnection = new SqlConnection(dbconnectionstring))
            {
                string sqlFetchQuery = "SELECT * from dbo.StudentTB;";
                SqlCommand dbcommand = new SqlCommand(sqlFetchQuery, dbconnection);
                dbconnection.Open();
                SqlDataReader dbreader = dbcommand.ExecuteReader();
                if (dbreader.HasRows)
                {
                    while (dbreader.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.Id = dbreader.GetInt32(0);
                        student.First_Name = dbreader.GetString(1);
                        student.Last_Name = dbreader.GetString(2);
                        student.University = dbreader.GetString(3);
                        student.Faculty = dbreader.GetString(4);
                        student.Grade = dbreader.GetInt32(5);
                        student.Study_Type = dbreader.GetString(6);
                        student.Kvota = dbreader.GetString(7);
                        returnstudent.Add(student);
                    }
                }
            }
            return returnstudent;
        }
        public StudentModel FetchOneStudent(int Id)
        {
            using (SqlConnection dbconnection = new SqlConnection(dbconnectionstring))
            {
                string sqlFetchQuery = "SELECT * from dbo.StudentTB WHERE ID = @Id;";
                SqlCommand dbcommand = new SqlCommand(sqlFetchQuery, dbconnection);
                dbcommand.Parameters.Add("@Id", System.Data.SqlDbType.Int, 50).Value = Id;
                dbconnection.Open();
                SqlDataReader dbreader = dbcommand.ExecuteReader();
                StudentModel student = new StudentModel();
                if (dbreader.HasRows)
                {
                    while (dbreader.Read())
                    {
                        student.Id = dbreader.GetInt32(0);
                        student.First_Name = dbreader.GetString(1);
                        student.Last_Name = dbreader.GetString(2);
                        student.University = dbreader.GetString(3);
                        student.Faculty = dbreader.GetString(4);
                        student.Grade = dbreader.GetInt32(5);
                        student.Study_Type = dbreader.GetString(6);
                        student.Kvota = dbreader.GetString(7);
                    }
                }
                return student;
            }
        }
        public int CreateOrUpdateStudent(StudentModel studentmodel)
        {
            using (SqlConnection dbconnection = new SqlConnection(dbconnectionstring))
            {
                string sqlInsertOrUbdateQuery = "";
                if (studentmodel.Id <= 0)
                {
                    sqlInsertOrUbdateQuery = "INSERT INTO dbo.StudentTB VALUES(@First_Name, @Last_Name, @University, @Faculty, @Grade, @Study_Type, @Kvota);";
                }
                else
                {
                    sqlInsertOrUbdateQuery = "UPDATE dbo.StudentTB SET First_Name = @First_Name, Last_Name = @Last_Name, University = @University, Faculty = @Faculty, Grade = @Grade, Study_Type = @Study_Type, Kvota = @Kvota WHERE ID = @Id;";
                }
                SqlCommand dbcommand = new SqlCommand(sqlInsertOrUbdateQuery, dbconnection);
                dbcommand.Parameters.Add("@Id", System.Data.SqlDbType.Int, 50).Value = studentmodel.Id;
                dbcommand.Parameters.Add("@First_Name", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.First_Name;
                dbcommand.Parameters.Add("@Last_Name", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.Last_Name;
                dbcommand.Parameters.Add("@University", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.University;
                dbcommand.Parameters.Add("@Faculty", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.Faculty;
                dbcommand.Parameters.Add("@Grade", System.Data.SqlDbType.Int, 50).Value = studentmodel.Grade;
                dbcommand.Parameters.Add("@Study_Type", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.Study_Type;
                dbcommand.Parameters.Add("@Kvota", System.Data.SqlDbType.VarChar, 50).Value = studentmodel.Kvota;
                dbconnection.Open();
                int newId = dbcommand.ExecuteNonQuery();
                return newId;
            }
        }
        public int DeleteStudent(int Id)
        {
            using (SqlConnection dbconnection = new SqlConnection(dbconnectionstring))
            {
                string sqlDeleteQuery = "DELETE FROM dbo.StudentTB WHERE ID = @Id";
                StudentModel studentmodel = new StudentModel();
                SqlCommand dbcommand = new SqlCommand(sqlDeleteQuery, dbconnection);
                dbcommand.Parameters.Add("@Id", System.Data.SqlDbType.Int, 50).Value = Id;
                dbconnection.Open();
                int deletedId = dbcommand.ExecuteNonQuery();
                return deletedId;
            }
        }
        public List<StudentModel> SearchForName(string searchPhrase)
        {
            List<StudentModel> returnstudent = new List<StudentModel>();
            using (SqlConnection dbconnection = new SqlConnection(dbconnectionstring))
            {
                string sqlFetchQuery = "SELECT * from dbo.StudentTB WHERE (First_Name LIKE @search);";
                SqlCommand dbcommand = new SqlCommand(sqlFetchQuery, dbconnection);
                dbcommand.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";
                dbconnection.Open();
                SqlDataReader dbreader = dbcommand.ExecuteReader();
                if (dbreader.HasRows)
                {
                    while (dbreader.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.Id = dbreader.GetInt32(0);
                        student.First_Name = dbreader.GetString(1);
                        student.Last_Name = dbreader.GetString(2);
                        student.University = dbreader.GetString(3);
                        student.Faculty = dbreader.GetString(4);
                        student.Grade = dbreader.GetInt32(5);
                        student.Study_Type = dbreader.GetString(6);
                        student.Kvota = dbreader.GetString(7);
                        returnstudent.Add(student);
                    }
                }
            }
            return returnstudent;
        }
    }
}
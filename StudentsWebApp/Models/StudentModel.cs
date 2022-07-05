using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsWebApp.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string Faculty { get; set;}
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Study_Type { get; set; }
        [Required]
        public string Kvota { get; set; }
        public StudentModel()
        {
            Id = -1;
        }
        public StudentModel(int id, string first_Name, string last_Name, string university, string faculty, int grade, string study_Type, string kvota)
        {
            Id = id;
            First_Name = first_Name;
            Last_Name = last_Name;
            University = university;
            Faculty = faculty;
            Grade = grade;
            Study_Type = study_Type;
            Kvota = kvota;
        }
    }
}
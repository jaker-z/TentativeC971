using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;


namespace TentativeC971
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        //public List<Course> Courses { get; set; }

        public ObservableCollection<Course> Courses { get; set; } = new();

        public Term()
        {
            Name = "Term " + Id.ToString();
            //Courses = new List<Course>();
        }

        public Term(int id)
        {
            Id = id;
            Name = "Term " + Id.ToString();
            //Courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
        
    }
}

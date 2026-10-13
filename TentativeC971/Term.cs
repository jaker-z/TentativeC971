using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TentativeC971
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Course> Courses { get; set; }

        public Term()
        {
            Name = "Term " + Id.ToString();
        }

        public Term(string name)
        {
            Name = name;
        }
        
    }
}

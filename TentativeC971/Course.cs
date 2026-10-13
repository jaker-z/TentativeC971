using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TentativeC971
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}

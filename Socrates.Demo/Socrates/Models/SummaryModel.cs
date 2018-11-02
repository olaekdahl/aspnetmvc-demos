using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socrates.Models
{
    public class SummaryModel
    {
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
    }
}
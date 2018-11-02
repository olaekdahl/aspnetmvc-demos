using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socrates.Models
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Department> Departments { get; set; }

        public IEnumerable<SelectListItem> DepartmentList
        {
            get
            {
                return from d in Departments
                       select new SelectListItem()
                       {
                           Value = d.Id.ToString(),
                           Text = d.Name,
                           Selected = (d.Id == Course.Department.Id)
                       };
            }
        }
    }
}
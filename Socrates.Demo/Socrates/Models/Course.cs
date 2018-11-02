using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Socrates.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[A-Z]+-\d+", ErrorMessage = "The format has to match ABC-123")]
        public string Number { get; set; }
        [Required(ErrorMessage = "You have to specify a title")]
        [StringLength(4)]
        public string Title { get; set; }
        [Required]
        public float Duration { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date")]
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DataType(DataType.Date)]
        //[ScaffoldColumn(false)]
        public DateTime AvailabilityDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set;  }
    }
}
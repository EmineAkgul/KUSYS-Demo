using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.DTOs
{
    public class StudentDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid CourseId { get; set; }

        //nav props
        //public CourseDTO Course { get; set; }
    }
}

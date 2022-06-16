using KUSYS_Demo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.Model
{
    public class CreateStudentModel
    {
        public StudentDTO Student { get; set; }
        public List<CourseDTO> Courses { get; set; }
    }
}

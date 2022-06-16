using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.DTOs
{
    public class CourseDTO: BaseDTO
    {
        public string CourseName { get; set; }
        public string CourseId { get; set; }

        //nav props
        //public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Domain.Entity
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseId { get; set; }

        //nav props
        public List<Student> Students { get; set; } = new List<Student>();
    }
}

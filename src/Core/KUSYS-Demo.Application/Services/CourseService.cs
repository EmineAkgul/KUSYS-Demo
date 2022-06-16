using KUSYS_Demo.Application.DTOs;
using KUSYS_Demo.Application.IRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<List<CourseDTO>> GetAllCourses()
        {
            var list = await courseRepository.GetAllAsync();
            if (list != null && list.Count > 0)
                return list.Adapt<List<CourseDTO>>();
            else
                return null;
        }
    }
}

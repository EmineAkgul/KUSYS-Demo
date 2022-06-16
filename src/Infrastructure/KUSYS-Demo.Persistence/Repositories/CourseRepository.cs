using KUSYS_Demo.Application.DTOs;
using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Domain.Entity;
using KUSYS_Demo.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {

        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<List<Student>> GetCourseStudentsAsync(Guid courseId)
        {
            return await context.Students.Where(c => c.CourseId == courseId).Include(c => c.Course).ToListAsync();
        }
    }
}

using KUSYS_Demo.Domain.Entity;
using KUSYS_Demo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Persistence.Seed
{
    public static class DbSeed
    {
        public static async void Initialize(IServiceProvider serviceProvider, bool create = false)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Database.Migrate();

            if (!dbContext.Courses.Any())
            {
                var list = new List<Course>()
                {
                    new Course() { IsDeleted = false, CreatedDate=DateTime.Now, CourseId="CSI101", CourseName = "Introduction to Computer Science" },
                    new Course() { IsDeleted = false, CreatedDate=DateTime.Now, CourseId="CSI102", CourseName = "Algorithms" },
                    new Course() { IsDeleted = false, CreatedDate=DateTime.Now, CourseId="MAT101", CourseName = "Calculus"},
                    new Course() { IsDeleted = false, CreatedDate=DateTime.Now, CourseId="PHY101", CourseName = "Physics"}
                };

                await dbContext.Courses.AddRangeAsync(list);
                await dbContext.SaveChangesAsync();
            }
           

        }
    }
}

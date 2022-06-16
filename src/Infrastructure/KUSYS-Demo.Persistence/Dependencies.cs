using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Persistence.Context;
using KUSYS_Demo.Persistence.Repositories;
using KUSYS_Demo.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Persistence
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
         
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddTransient<IStudentRepository, StudentRepository>();
            serviceCollection.AddTransient<ICourseRepository, CourseRepository>();

        }

        public static void AddSeed(IServiceProvider serviceProvider)
        {
            DbSeed.Initialize(serviceProvider, true);
        }
    }
}

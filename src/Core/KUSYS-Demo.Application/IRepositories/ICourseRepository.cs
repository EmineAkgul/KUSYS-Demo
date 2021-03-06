
using KUSYS_Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.IRepositories
{
    public interface ICourseRepository: IRepository<Course>
    {
        Task<List<Student>> GetCourseStudentsAsync(Guid courseId);

    }
}

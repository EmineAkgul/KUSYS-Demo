using KUSYS_Demo.Application.DTOs;
using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Domain.Entity;
using KUSYS_Demo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {

        public StudentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}

using KUSYS_Demo.Application.DTOs;
using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Domain.Entity;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Application.Services
{
    public class StudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var list = await studentRepository.GetAllAsync();
            if (list != null && list.Count > 0)
                return list.Adapt<List<StudentDTO>>();
            else
                return null;
        }

        public async Task<StudentDTO> GetStudentById(Guid Id)
        {
            var student = await studentRepository.GetByIdAsync(Id); 
            if(student is null)
            {
                return null;
            }
            else
            {
                return student.Adapt<StudentDTO>();
            }
        }

        public async Task<StudentDTO> AddStudent(StudentDTO model)
        {
            model.CreatedDate = DateTime.Now;

            var student = await studentRepository.AddAsync(model.Adapt<Student>());
            if (student != null)
                return student.Adapt<StudentDTO>();
            else
                return null;
        }

        public async Task<StudentDTO> DeleteStudent(Guid Id)
        {

            var student = await studentRepository.DeleteAsync(Id);
            if (student != null)
                return student.Adapt<StudentDTO>();
            else
                return null;
        }

        public async Task<StudentDTO> UpdateStudent(StudentDTO model)
        {
            var student = await studentRepository.GetByIdAsync(model.Id);
            if(student is null)
                return null;
            else
            {
                var createDate = student.CreatedDate;
                var updated = model.Adapt(student);
                updated.CreatedDate = createDate;
                var result = await studentRepository.UpdateAsync(updated);
                if (result != null)
                    return result.Adapt<StudentDTO>();
                else
                    return null;
            }
        }

    }
}

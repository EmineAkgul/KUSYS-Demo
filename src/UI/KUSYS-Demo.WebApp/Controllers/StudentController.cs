using KUSYS_Demo.Application.DTOs;
using KUSYS_Demo.Application.IRepositories;
using KUSYS_Demo.Application.Model;
using KUSYS_Demo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        StudentService studentService;
        CourseService courseService;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this.studentRepository = studentRepository;
            studentService = new StudentService(studentRepository);
            this.courseRepository = courseRepository;
            courseService = new CourseService(courseRepository);
        }
        public async Task<IActionResult> Index(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
            }

            var studentList = await studentService.GetAllStudents();

            return View(studentList);
        }

        public async Task<IActionResult> Create()
        {
            var courseList = await courseService.GetAllCourses();

            var model = new CreateStudentModel();
            model.Courses = courseList;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentModel model)
        {
            if (model is null)
            {
                return RedirectToAction("Index", new { errorMessage = "Bilgileri eksiksiz giriniz" });
            }

            var added = await studentService.AddStudent(model.Student);
            if(added != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { errorMessage = "Öğrenci kaydedilemedi" });
            }
        }

        public async Task<IActionResult> Delete(Guid? Id)
        {
            if (Id is null || Id==Guid.Empty)
            {
                return RedirectToAction("Index", new { errorMessage = "Bilgileri eksiksiz giriniz" });
            }

            var deleted = await studentService.DeleteStudent(Id.Value);
            if (deleted != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { errorMessage = "Öğrenci silinemedi" });
            }
        }

        public async Task<IActionResult> Details(Guid? Id)
        {
            if (Id is null || Id == Guid.Empty)
            {
                return Json( new { failed = true, message = "Bilgileri eksiksiz giriniz" });
            }

            var student = await studentService.GetStudentById(Id.Value);
            if(student is null)
                return Json(new { failed=true, message="Kullanıcı kaydı bulunamadı" });
            else
            {
                var model = new CreateStudentModel();

                var courseList = await courseService.GetAllCourses();
                model.Courses = courseList;
                model.Student = student;
                return PartialView("~/Views/Student/_UserEditPartial.cshtml", model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateStudentModel model)
        {
            if (model is null)
            {
                return RedirectToAction("Index", new { errorMessage = "Bilgileri eksiksiz giriniz" });
            }

            var updated = await studentService.UpdateStudent(model.Student);
            if (updated != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { errorMessage = "Öğrenci güncellenemedi" });
            }
        }

    }
}

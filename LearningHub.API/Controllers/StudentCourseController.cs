using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService _studentCourseService;
        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }
        [HttpGet]
        public List<Stdcourse> GetAllStdCourses()
        {
            return _studentCourseService.GetAllStdCourses();
        }
        [HttpGet]
        [Route("GetStdCourse/{id}")]
        public Stdcourse GetStdCourse(int id)
        {
            return _studentCourseService.GetStdCourse(id);
        }
        [HttpPost]
        [Route("CreateStdCourse")]
        public void CreateStdCourse(Stdcourse stdcourse)
        {
            _studentCourseService.CreateStdCourse(stdcourse);
        }
        [HttpPut]
        [Route("UpdateStdCourse")]
        public void UpdateStdCourse(Stdcourse stdcourse)
        {
            _studentCourseService.UpdateStdCourse(stdcourse);
        }
        [HttpDelete]
        [Route("DeleteStdCourse/{id}")]
        public void DeleteStdCourse(int id)
        {
            _studentCourseService.DeleteStdCourse(id);
        }
        [HttpGet]
        [Route("GetStdCourseByStudentId/{id}")]
        public List<Stdcourse> GetStdCourseByStudentId(int id)
        {
           return _studentCourseService.GetStdCourseByStudentId(id);
        }
        [HttpGet]
        [Route("GetStdCourseByCourseId/{id}")]
        public List<Stdcourse> GetStdCourseByCourseId(int id)
        {
            return _studentCourseService.GetStdCourseByCourseId(id);
        }
        [HttpPost]
        [Route("GetSearchStudentCourses")]
        public List<SearchStudentCourse> GetSearchStudentCourses(SearchStudentCourse obj)
        {
           return _studentCourseService.GetSearchStudentCourses(obj);
        }
        [HttpGet]
        [Route("GetTotalNumberOfStudentForEachCourse")]
        public List<TotalNumberOfStudentForEachCourse> GetTotalNumberOfStudentForEachCourse()
        {
           return _studentCourseService.GetTotalNumberOfStudentForEachCourse();
        }

    }
}

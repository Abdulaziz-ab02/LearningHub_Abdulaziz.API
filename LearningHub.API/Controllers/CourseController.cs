using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return _courseService.GetAllCourses();
        }

        [HttpGet]
        [Route("GetCourseById/{id}")]
        public Course GetCourseById(int id)
        {
            return _courseService.GetCourseById(id);
        }
        [HttpPost]
        [Route("CreateCourse")]
        public void CreateCourse(Course course)
        {
            _courseService.CreateCourse(course);
        }
        [HttpPut]
        [Route("UpdateCourse")]

        public void UpdateCourse(Course course)
        {
            _courseService.UpdateCourse(course);
        }
        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public void DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Course UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            item.Imagename = fileName;
            return item;

        }
    }
}

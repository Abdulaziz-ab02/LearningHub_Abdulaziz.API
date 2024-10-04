using Dapper;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepoitory _courseRepoitory;
        public CourseService(ICourseRepoitory courseRepoitory)
        {
            _courseRepoitory = courseRepoitory;
        }

        public List<Course> GetAllCourses()
        {
            return _courseRepoitory.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepoitory.GetCourseById(id);
        }

        public void CreateCourse(Course course)
        {
             _courseRepoitory.CreateCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepoitory.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseRepoitory.DeleteCourse(id);
        }

    }
}

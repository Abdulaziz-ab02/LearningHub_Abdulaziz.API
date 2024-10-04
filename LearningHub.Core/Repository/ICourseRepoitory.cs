using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface ICourseRepoitory
    {
        List<Course> GetAllCourses();

        Course GetCourseById(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}

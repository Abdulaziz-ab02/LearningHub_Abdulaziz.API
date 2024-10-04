using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IStudentCourseService
    {
        List<Stdcourse> GetAllStdCourses();
        Stdcourse GetStdCourse(int id);
        void CreateStdCourse(Stdcourse stdcourse);
        void UpdateStdCourse(Stdcourse stdcourse);
        void DeleteStdCourse(int id);
        List<Stdcourse> GetStdCourseByStudentId(int id);
        List<Stdcourse> GetStdCourseByCourseId(int id);
        public List<SearchStudentCourse> GetSearchStudentCourses(SearchStudentCourse obj);
        public List<TotalNumberOfStudentForEachCourse> GetTotalNumberOfStudentForEachCourse();

    }
}

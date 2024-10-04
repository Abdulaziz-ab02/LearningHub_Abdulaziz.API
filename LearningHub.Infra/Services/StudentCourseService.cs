using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class StudentCourseService: IStudentCourseService
    {
        private IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }
        public List<Stdcourse> GetAllStdCourses()
        {
          return _studentCourseRepository.GetAllStdCourses();
        }

        public Stdcourse GetStdCourse(int id)
        {
            return _studentCourseRepository.GetStdCourse(id);
        }
        public void CreateStdCourse(Stdcourse stdcourse)
        {
            _studentCourseRepository.CreateStdCourse(stdcourse);
        }
        public void UpdateStdCourse(Stdcourse stdcourse)
        {
             _studentCourseRepository.UpdateStdCourse(stdcourse);
        }
        public void DeleteStdCourse(int id)
        {
            _studentCourseRepository.DeleteStdCourse(id);
        }
        public List<Stdcourse> GetStdCourseByStudentId(int id)
        {
            return _studentCourseRepository.GetStdCourseByStudentId(id);
        }
        public List<Stdcourse> GetStdCourseByCourseId(int id)
        {
            return _studentCourseRepository.GetStdCourseByCourseId(id);
        }
        public List<SearchStudentCourse> GetSearchStudentCourses(SearchStudentCourse obj)
        {
           return _studentCourseRepository.GetSearchStudentCourses(obj);
        }
        public List<TotalNumberOfStudentForEachCourse> GetTotalNumberOfStudentForEachCourse()
        {
           return _studentCourseRepository.GetTotalNumberOfStudentForEachCourse();
        }
    }
}

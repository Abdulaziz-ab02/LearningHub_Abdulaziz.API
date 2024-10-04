using Dapper;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
        public void CreateStudent(Student student)
        {
            _studentRepository.CreateStudent(student);
        }
        public void UpdateStudent(Student student)
        {
            _studentRepository.UpdateStudent(student);
        }
        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
        public List<Student> GetFirstNameAndLastName()
        {
            return _studentRepository.GetFirstNameAndLastName();
        }
        public List<Student> GetStudentByFirstName(Student name)
        {
            return _studentRepository.GetStudentByFirstName(name);
        }
        public List<Student> GetStudentByDateOfBirth(Student date)
        {
            return _studentRepository.GetStudentByDateOfBirth(date);
        }
        public List<Student> GetStudentByDateOfBirthInterval(DateTime startDate, DateTime endDate)
        {
            return _studentRepository.GetStudentByDateOfBirthInterval(startDate, endDate);
        }
        public List<Student> GetTheNofTopStudentByMarks(int num)
        {
            return _studentRepository.GetTheNofTopStudentByMarks(num);
        }

    }
}

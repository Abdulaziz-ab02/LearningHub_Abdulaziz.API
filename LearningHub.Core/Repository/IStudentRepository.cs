using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        List<Student> GetFirstNameAndLastName();
        List<Student> GetStudentByFirstName(Student name);
        List<Student> GetStudentByDateOfBirth(Student date);
        List<Student> GetStudentByDateOfBirthInterval(DateTime startDate, DateTime endDate);
        List<Student> GetTheNofTopStudentByMarks(int num);
        
    }
}

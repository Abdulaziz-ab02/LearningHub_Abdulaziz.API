using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPost]
        [Route("CreateStudent")]
        public void CreateStudent(Student student)
        {
            _studentService.CreateStudent(student);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }

        [HttpGet]
        [Route("GetFirstNameAndLastName")]
        public List<Student> GetFirstNameAndLastName()
        {
            return _studentService.GetFirstNameAndLastName();
        }

        [HttpGet]
        [Route("GetStudentByFirstName/{name}")]
        public List<Student> GetStudentByFirstName(Student name)
        {
            return _studentService.GetStudentByFirstName(name);
        }

        [HttpGet]
        [Route("GetStudentByDateOfBirth/{date}")]
        public List<Student> GetStudentByDateOfBirth(Student date)
        {
            return _studentService.GetStudentByDateOfBirth(date);
        }

        [HttpGet]
        [Route("GetStudentByDateOfBirthInterval/{startDate}/{endDate}")]
        public List<Student> GetStudentByDateOfBirthInterval(DateTime startDate, DateTime endDate)
        {
            return _studentService.GetStudentByDateOfBirthInterval(startDate, endDate);
        }

        [HttpGet]
        [Route("GetTheNofTopStudentByMarks/{num}")]
        public List<Student> GetTheNofTopStudentByMarks(int num)
        {
            return _studentService.GetTheNofTopStudentByMarks(num);
        }
    }
}

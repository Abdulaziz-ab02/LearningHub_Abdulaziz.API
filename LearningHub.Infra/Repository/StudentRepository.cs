using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetAllStudents()
        {
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetAllStudents",commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Student GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("P_FirstName", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_LastName", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_DateOfBirth", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Student_Package.CreateStudent", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("P_FirstName", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_LastName", student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("P_DateOfBirth", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Student_Package.UpdateStudent", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Student_Package.DeleteStudent", p, commandType: CommandType.StoredProcedure);

        }

        public List<Student> GetFirstNameAndLastName()
        {
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetFirstNameAndLastName",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentByFirstName(Student name)
        {
            var p = new DynamicParameters();
            p.Add("P_FirstName",name.Firstname,dbType:DbType.String,
                direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetStudentByFirstName",p,
                commandType:CommandType.StoredProcedure);
            return result.ToList();


        }
        public List<Student> GetStudentByDateOfBirth(Student date)
        {
            var p = new DynamicParameters();
            p.Add("P_DateOfBirth",date.Dateofbirth,dbType:DbType.DateTime,
                direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetStudentByDateOfBirth",p,
                commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentByDateOfBirthInterval(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("P_StartDate",startDate,dbType:DbType.DateTime,
                direction:ParameterDirection.Input);
            p.Add("P_EndDate",endDate,dbType:DbType.DateTime,
                direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetStudentByDateOfBirthInterval",p,
                commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetTheNofTopStudentByMarks(int num)
        {
            var p = new DynamicParameters();
            p.Add("P_N",num,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Student>("Student_Package.GetTopNStudentsByMarks",p,
                commandType:CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}

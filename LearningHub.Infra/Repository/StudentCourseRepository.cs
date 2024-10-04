using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repository
{
    public class StudentCourseRepository: IStudentCourseRepository
    {
        private readonly IDbContext _dbContext;

        public StudentCourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Stdcourse> GetAllStdCourses()
        {
            var result = _dbContext.Connection.Query<Stdcourse>("StdCourse_Package.GetAllStdCourses",CommandType.StoredProcedure);
            return result.ToList();
        }

        public Stdcourse GetStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Stdcourse>("StdCourse_Package.GetStdCourseById",p,commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateStdCourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("StudentId",stdcourse.Studentid,dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CourseId", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MarkOfStd", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DateOfRegister", stdcourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("StdCourse_Package.CreateStdCourse",p,commandType:CommandType.StoredProcedure);

        }

        public void UpdateStdCourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("StudentId", stdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CourseId", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MarkOfStd", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DateOfRegister", stdcourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("StdCourse_Package.UpdateStdCourse", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id",id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("StdCourse_Package.DeleteStdCourse", p, commandType: CommandType.StoredProcedure);

        }

        public List<Stdcourse> GetStdCourseByStudentId(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Stdcourse>("StdCourse_Package.GetStdCourseByStudentId", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Stdcourse> GetStdCourseByCourseId(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Stdcourse>("StdCourse_Package.GetStdCourseByCourseId",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<SearchStudentCourse> GetSearchStudentCourses(SearchStudentCourse obj)
        {
            var p = new DynamicParameters();
            p.Add("cName",obj.Coursename,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("sName",obj.Firstname,dbType:DbType.String,direction:ParameterDirection.Input);
            p.Add("DateFrom",obj.DateFrom,dbType:DbType.DateTime,direction:ParameterDirection.Input);
            p.Add("DateTo", obj.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<SearchStudentCourse>("SearchStudentAndCourse",p
                ,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<TotalNumberOfStudentForEachCourse> GetTotalNumberOfStudentForEachCourse()
        {
            var result = _dbContext.Connection.Query<TotalNumberOfStudentForEachCourse>("TotalNumberOfStudentForEachCourse",
                commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
/*
      var p = new DynamicParameters();
       p.Add("cName", searchdto.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
       p.Add("sName", searchdto.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
       p.Add("DateFrom", searchdto.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
       p.Add("DateTo", searchdto.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);*/
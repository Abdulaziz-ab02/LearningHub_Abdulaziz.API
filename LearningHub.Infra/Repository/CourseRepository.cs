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
    public class CourseRepository : ICourseRepoitory
    {
        public readonly IDbContext _dbContext;
        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Course> GetAllCourses()
        {
            var result = _dbContext.Connection.Query<Course>("Course_Package.GetAllCourses",commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Course GetCourseById(int id)
        {
            var p = new DynamicParameters(); // pass data to database (stored procedure)
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("C_Name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catid", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Course_Package.CreateCourse", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("C_id", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("C_Name", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("catid", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Course_Package.UpdateCourse", p, commandType: CommandType.StoredProcedure);
        }
        //delete based on c_id 
        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);

        }
    }
}
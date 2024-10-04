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
    public class CategoryRepository: ICategoryRepository
    {
        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Category> GetAllCategories()
        {
        var result = _dbContext.Connection.Query<Category>("Category_Package.GetAllCategories",
            commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Category>("Category_Package.GetCategoryById",p,
                commandType:CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("C_Name",category.Categoryname,
                dbType:DbType.String,direction:ParameterDirection.Input);
            _dbContext.Connection.Execute("Category_Package.CreateCategory",p,
                commandType:CommandType.StoredProcedure);
        }
        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("Id",category.Categoryid,dbType:DbType.Int32,
                direction:ParameterDirection.Input);
            p.Add("C_Name",category.Categoryname,dbType:DbType.String,
                direction:ParameterDirection.Input);
            _dbContext.Connection.Execute("Category_Package.UpdateCategory",p,
                commandType:CommandType.StoredProcedure);
        }
        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            _dbContext.Connection.Execute("Category_Package.DeleteCategory",p,
                commandType:CommandType.StoredProcedure);
        }

        public async Task<List<Category>> GetAllCategoryCourse()
        {
            var p = new DynamicParameters();
            var result = await _dbContext.Connection.QueryAsync<Category, Course, Category>("GetAllCategoryCourse",
            (Category, course) =>
            {
                Category.Courses.Add(course);
                return Category;
            },
            splitOn: "Courseid",
            param: null,
            commandType: CommandType.StoredProcedure

            );
            var result2 = result.GroupBy(p => p.Categoryid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Courses = g.Select(p => p.Courses.Single()).ToList();
                return groupedPost;
            });
            return result2.ToList();
        }
        public async Task<List<Course>> GetAllCoursesWithStudents()
        {
            var result = await _dbContext.Connection.QueryAsync<Course, Stdcourse, Student, Course>(
                "GetAllCoursesForAllStudent",
                (course, stdcourse, student) =>
                {
                    // Properly map student data to stdcourse
                    stdcourse.Student = student;
                    // Add stdcourse to course
                    course.Stdcourses.Add(stdcourse);
                    return course;
                },
                splitOn: "Id,StudentID", // Make sure the splitOn matches the exact column names in SQL
                commandType: CommandType.StoredProcedure
            );

            // Group the result by CourseId and handle multiple Stdcourses
            var groupedResult = result.GroupBy(c => c.Courseid).Select(g =>
            {
                var groupedCourse = g.First();
                groupedCourse.Stdcourses = g.SelectMany(c => c.Stdcourses).ToList();
                return groupedCourse;
            });

            return groupedResult.ToList();
        }



    }


}




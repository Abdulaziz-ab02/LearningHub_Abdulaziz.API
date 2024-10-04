using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public Task<List<Category>> GetAllCategoryCourse();
        public Task<List<Course>> GetAllCoursesWithStudents();
    }
}

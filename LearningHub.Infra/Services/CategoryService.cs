using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
        public void CreateCategory(Category category)
        {
            _categoryRepository.CreateCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }
        public Task<List<Category>> GetAllCategoryCourse()
        {
            return _categoryRepository.GetAllCategoryCourse();
        }
        public Task<List<Course>> GetAllCoursesWithStudents()
        {
           return _categoryRepository.GetAllCoursesWithStudents();
        }

    }
}

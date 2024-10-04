using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Category category)
        {
            _categoryService.CreateCategory(category);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }
        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<Category>> GetAllCategoryCourse()
        {
            return _categoryService.GetAllCategoryCourse();
        }
        [HttpGet]
        [Route("GetAllCoursesWithStudents")]
        public  Task<List<Course>> GetAllCoursesWithStudents()
        {
            return _categoryService.GetAllCoursesWithStudents();
        }

    }
}

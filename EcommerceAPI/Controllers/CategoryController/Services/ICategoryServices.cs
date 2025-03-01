using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers.CategoryController.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(Guid categoryId);
        Task<Category> CreateCategory(Category category);
        Task<bool> UpdateCategory(Guid categoryId, Category category);
        Task<bool> DeleteCategory(Guid categoryId);
    }
}

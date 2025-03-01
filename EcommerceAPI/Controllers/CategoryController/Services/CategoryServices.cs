using EcommerceAPI.Data;
using EcommerceAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.CategoryController.Services 
{
    public class CategoryService : ICategoryService
    {
        private readonly EcommerceDbContext _context;

        public CategoryService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(Guid categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            category.Id = Guid.NewGuid();
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> UpdateCategory(Guid categoryId, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(categoryId);
            if (existingCategory == null)
                return false;

            existingCategory.Name = category.Name;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

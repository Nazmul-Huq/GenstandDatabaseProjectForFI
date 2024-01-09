using GenstandDatabaseProjectForFI.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Repositories
{
    public class CategoryRepository : ICategoryOperations
    {

        private readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Category> AddCategoryAsync(Category model)
        {
            if (model is null) return null!;


            var newDataAdded = applicationDbContext.Categories.Add(model).Entity;
            await applicationDbContext.SaveChangesAsync();
            return newDataAdded;
        }

        public async Task<Category> DeleteCategoryAsync(int categoryId)
        {
            var category = await applicationDbContext.Categories.FirstOrDefaultAsync(g => g.Id == categoryId);
            if (category is null) return null!;
            applicationDbContext.Categories.Remove(category);
            await applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategorysAsync()
        {
            var categories = await applicationDbContext.Categories.ToListAsync();
            if (categories is null) return null!;
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int catergoryId)
        {
            var categorys = await applicationDbContext.Categories.FirstOrDefaultAsync(g => g.Id == catergoryId);
            if (categorys is null) return null!;
            return categorys;
        }

        public async Task<Category> UpdateCategoryAsync(Category model)
        {
            var category = await applicationDbContext.Categories.FirstOrDefaultAsync(g => g.Id == model.Id);
            if (category is null) return null!;
            category.Name = model.Name;
            await applicationDbContext.SaveChangesAsync();
            return await applicationDbContext.Categories.FirstOrDefaultAsync(g => g.Id == model.Id)!;
        }
    }
}

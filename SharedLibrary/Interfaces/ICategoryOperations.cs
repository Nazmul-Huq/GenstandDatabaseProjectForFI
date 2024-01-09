using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface ICategoryOperations
    {
        Task<Category> AddCategoryAsync(Category model);
        Task<List<Category>> GetAllCategorysAsync();
        Task<Category> DeleteCategoryAsync(int categoryId);
        Task<Category> GetCategoryByIdAsync(int CategoryId);
        Task<Category> UpdateCategoryAsync(Category model);
    }
}

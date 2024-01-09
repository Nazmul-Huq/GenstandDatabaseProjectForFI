using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly ICategoryOperations categoryOperations;
        public CategoryController(ICategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }

        [HttpPost("Add-Category")]
        public async Task<ActionResult<List<Category>>> AddProductAsync(Category model)
        {
            var product = await categoryOperations.AddCategoryAsync(model);
            return Ok(product);
        }

        [HttpGet("Get-All-Categorys")]
        public async Task<ActionResult<List<Category>>> GetAllCategorysAsync()
        {
            var categorys = await categoryOperations.GetAllCategorysAsync();
            return Ok(categorys);
        }


        [HttpDelete("Delete-Category/{id}")]
        public async Task<ActionResult<Category>> DeleteCategoryAsync(int id)
        {
            var product = await categoryOperations.DeleteCategoryAsync(id);
            return Ok(product);
        }


        [HttpGet("Single-Genstand/{id}")]
        public async Task<ActionResult<List<Category>>> GetSingleCategoryAsync(int id)
        {
            var categorys = await categoryOperations.GetCategoryByIdAsync(id);
            return Ok(categorys);
        }

        [HttpPut("Update-Category")]
        public async Task<ActionResult<Category>> UpdateCategoryAsync(Category model)
        {
            var product = await categoryOperations.UpdateCategoryAsync(model);
            return Ok(product);
        }

    }
}

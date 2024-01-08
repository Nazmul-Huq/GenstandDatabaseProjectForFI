using GenstandDatabaseProjectForFI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenstandController : ControllerBase
    {
        private readonly IGenstandOperations genstandOperations;
        private readonly IFilmOperations filmOperations;
        public GenstandController(IGenstandOperations genstandOperations, IFilmOperations filmOperations)
        {
            this.genstandOperations = genstandOperations;
            this.filmOperations = filmOperations;
        }

        [HttpPost("Add-Genstand")]
        public async Task<ActionResult<List<Genstand>>> AddProductAsync(GenstandDto model)
        {
            if (model == null) return BadRequest(ModelState);
            Film film = await filmOperations.GetFilmByIdAsync(model.FilmId);
            Genstand genstandToSave = new Genstand { 
                Name = model.Name,
                Description = model.Description,
                DateOfGenstand = model.DateOfGenstand,
                Size = model.Size,
                PhotoReference = model.PhotoReference,
                Placement = model.Placement,
                Condition = model.Condition,
                Loan = model.Loan,
                //FilmId = model.FilmId,
                Film = film
            };
            var savedGenstand = await genstandOperations.AddGenstandAsync(genstandToSave);
            return Ok(savedGenstand);
        }

        //[HttpPost("Add-Genstand")]
        //public async Task<ActionResult<List<Genstand>>> AddProductAsync(Genstand model)
        //{
        //    var product = await genstandOperations.AddGenstandAsync(model);
        //    return Ok(product);
        //}

        [HttpGet("Get-All-Genstands")]
        public async Task<ActionResult<List<Genstand>>> GetAllGenstandsAsync()
        {
            var genstands = await genstandOperations.GetAllGenstandsAsync();
            return Ok(genstands);
        }


        [HttpDelete("Delete-Genstand/{id}")]
        public async Task<ActionResult<Genstand>> DeleteGenstandAsync(int id)
        {
            var product = await genstandOperations.DeleteGenstandAsync(id);
            return Ok(product);
        }


        [HttpGet("Single-Genstand/{id}")]
        public async Task<ActionResult<List<Genstand>>> GetSingleGenstandAsync(int id)
        {
            var genstand = await genstandOperations.GetGenstandByIdAsync(id);
            return Ok(genstand);
        }

        [HttpPut("Update-Genstand")]
        public async Task<ActionResult<Genstand>> UpdateGenstandAsync(Genstand model)
        {
            var product = await genstandOperations.UpdateGenstandAsync(model);
            return Ok(product);
        }

        [HttpGet("Search-Genstand-By-Name/{searchText}")]
        public async Task<ActionResult<List<Genstand>>> SearchGenstandByNameAsync(string searchText)
        {
            if (searchText == null) { return BadRequest(); }
            var genstands = await genstandOperations.SearchGenstandByNameAsync(searchText);
            return Ok(genstands);
        }

    }
}

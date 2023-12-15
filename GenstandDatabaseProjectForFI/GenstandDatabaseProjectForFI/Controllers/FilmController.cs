using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmOperations filmOperations;
        public FilmController(IFilmOperations filmOperations)
        {
            this.filmOperations = filmOperations;
        }

        [HttpPost("Add-Film")]
        public async Task<ActionResult<List<Film>>> AddFilmAsync(FilmDto filmDto)
        {
            if (filmDto == null) BadRequest();
            Film newFilm = new Film(filmDto.Name, filmDto.Year ,filmDto.Genre, filmDto.Fida);
            var film = await filmOperations.AddFilmAsync(newFilm);
            return Ok(film);
        }

        //[HttpGet("Single-Genstand/{id}")]
        //public async Task<ActionResult<List<Genstand>>> GetSingleGenstandAsync(int id)
        //{
        //    var genstand = await genstandOperations.GetGenstandByIdAsync(id);
        //    return Ok(genstand);
        //}

        //[HttpGet("Get-All-Genstands")]
        //public async Task<ActionResult<List<Genstand>>> GetAllGenstandsAsync()
        //{
        //    var genstands = await genstandOperations.GetAllGenstandsAsync();
        //    return Ok(genstands);
        //}
    }
}

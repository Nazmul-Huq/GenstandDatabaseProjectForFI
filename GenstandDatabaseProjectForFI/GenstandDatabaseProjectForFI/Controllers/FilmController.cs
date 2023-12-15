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

        [HttpGet("Single-Film/{id}")]
        public async Task<ActionResult<Film>> GetSingleFilmAsync(int id)
        {
            var film = await filmOperations.GetFilmByIdAsync(id);
            return Ok(film);
        }

        [HttpGet("Get-All-Films")]
        public async Task<ActionResult<List<Film>>> GetAllFilmsAsync()
        {
            var films = await filmOperations.GetAllFilmsAsync();
            return Ok(films);
        }
    }
}

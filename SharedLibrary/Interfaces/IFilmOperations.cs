using SharedLibrary.Models;

namespace SharedLibrary.Interfaces
{
    // actions can performed on film
    public interface IFilmOperations
    {
        Task<Film> AddFilmAsync(Film film);
        Task<List<Film>> GetAllFilmsAsync();
        Task<Film> DeleteFilmAsync(int filmId);
        Task<Film> GetFilmByIdAsync(int filmId);
        Task<Film> UpdateFilmAsync(Film film);
    }
}

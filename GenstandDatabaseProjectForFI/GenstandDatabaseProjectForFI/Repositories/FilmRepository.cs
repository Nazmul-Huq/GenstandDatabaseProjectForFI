using GenstandDatabaseProjectForFI.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Repositories
{
    public class FilmRepository : IFilmOperations
    {
        private readonly ApplicationDbContext applicationDbContext;

        public FilmRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Film> AddFilmAsync(Film film)
        {
            if (film is null) return null!;

            // we should also chek if the film already exist or not before we add it to the database

            var newDataAdded = applicationDbContext.Films.Add(film).Entity;
            await applicationDbContext.SaveChangesAsync();
            return newDataAdded;

        }

        public Task<Film> DeleteFilmAsync(int filmId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
      
            var films = await applicationDbContext.Films.ToListAsync();
            if (films is null) return null!;
            return films;
           
        }

        public async Task<Film> GetFilmByIdAsync(int filmId)
        {
            var film = await applicationDbContext.Films.FirstOrDefaultAsync(f => f.Id == filmId);
            if (film is null) return null!;
            return film;
        }

        public Task<Film> UpdateFilmAsync(Film film)
        {
            throw new NotImplementedException();
        }
    }
}

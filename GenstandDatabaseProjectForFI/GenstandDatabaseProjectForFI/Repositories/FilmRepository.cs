using GenstandDatabaseProjectForFI.Data;
using Humanizer.Localisation;
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

        public async Task<Film> DeleteFilmAsync(int filmId)
        {
            var film = await applicationDbContext.Films.FirstOrDefaultAsync(g => g.Id == filmId);
            if (film is null) return null!;
            applicationDbContext.Films.Remove(film);
            await applicationDbContext.SaveChangesAsync();
            return film;
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

        public async Task<Film> UpdateFilmAsync(Film film)
        {
            var filmToUpdate = await applicationDbContext.Films.FirstOrDefaultAsync(F => F.Id == film.Id);
            if (filmToUpdate is null) return null!;
            filmToUpdate.Name = film.Name;
            filmToUpdate.Year = film.Year;
            filmToUpdate.Genre = film.Genre;
            filmToUpdate.Fida = film.Fida;
            await applicationDbContext.SaveChangesAsync();
            return await applicationDbContext.Films.FirstOrDefaultAsync(F => F.Id == film.Id)!;
        }
    }
}

using GenstandDatabaseProjectForFI.Data;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using System;
using System.Linq;

namespace GenstandDatabaseProjectForFI.Repositories
{
    public class GenstandRepository : IGenstandOperations
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GenstandRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
        // add a genstand to the databse
        public async Task<Genstand> AddGenstandAsync(Genstand model)
        {
            if (model is null) return null!;
            // missing some validation
            //var chk = await applicationDbContext.Genstands.Where(g => g.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefaultAsync();
            //if (chk is not null) return null!;

            var newDataAdded = applicationDbContext.Genstands.Add(model).Entity;
            await applicationDbContext.SaveChangesAsync();
            return newDataAdded;
        }

        // delete genstand based on id
        public async Task<Genstand> DeleteGenstandAsync(int genstandId)
        {
            var genstand = await applicationDbContext.Genstands.FirstOrDefaultAsync(g => g.Id == genstandId);
            if (genstand is null) return null!;
            applicationDbContext.Genstands.Remove(genstand);
            await applicationDbContext.SaveChangesAsync();
            return genstand;
        }

        // get all genstand from database
        public async Task<List<Genstand>> GetAllGenstandsAsync()
        {
            var genstands = await applicationDbContext.Genstands.ToListAsync();
            if (genstands is null) return null!;
            return genstands;
        }

        // get individual genstand by id
        public async Task<Genstand> GetGenstandByIdAsync(int genstandId)
        {
            var genstand = await applicationDbContext.Genstands.FirstOrDefaultAsync(g => g.Id == genstandId);
            if (genstand is null) return null!;
            var film = await applicationDbContext.Genstands.Entry(film).ReloadAsync();
            return genstand;
        }

        // search genstand based on search text
        public async Task<List<Genstand>> SearchGenstandByNameAsync(string SearchText)
        {
            if (SearchText == null) return null!;
            var genstands = await applicationDbContext.Genstands.Where(g => g.Name.Contains(SearchText)).ToListAsync();
            if (genstands is null) return null;
            return genstands;
        }
        
        // update a genstand
        public async Task<Genstand> UpdateGenstandAsync(Genstand model)
        {
            var genstand = await applicationDbContext.Genstands.FirstOrDefaultAsync(g => g.Id == model.Id);
            if (genstand is null) return null!;
            genstand.Name = model.Name;
            genstand.Description = model.Description;
            await applicationDbContext.SaveChangesAsync();
            return await applicationDbContext.Genstands.FirstOrDefaultAsync(g => g.Id == model.Id)!;
        }
    }
}

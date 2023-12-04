using GenstandDatabaseProjectForFI.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using System;

namespace GenstandDatabaseProjectForFI.Repositories
{
    public class GenstandRepository : IGenstandOperations
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GenstandRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Genstand> AddProductAsync(Genstand model)
        {
            if (model is null) return null!;
            var chk = await applicationDbContext.Genstands.Where(g => g.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null!;

            var newDataAdded = applicationDbContext.Genstands.Add(model).Entity;
            await applicationDbContext.SaveChangesAsync();
            return newDataAdded;
        }
    }
}

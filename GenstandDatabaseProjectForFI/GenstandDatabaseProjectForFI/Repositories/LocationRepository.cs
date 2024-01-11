using GenstandDatabaseProjectForFI.Data;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Repositories
{
    public class LocationRepository : ILocationOperations
    {

        private readonly ApplicationDbContext applicationDbContext;

        public LocationRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Location> AddLocationAsync(Location model)
        {
            if (model is null) return null!;
            

            var newDataAdded = applicationDbContext.Locations.Add(model).Entity;
            await applicationDbContext.SaveChangesAsync();
            return newDataAdded;

        }

        public async Task<Location> DeleteLocationAsync(int locationId)
        {
            var location = await applicationDbContext.Locations.FirstOrDefaultAsync(g => g.Id == locationId);
            if (location is null) return null!;
            applicationDbContext.Locations.Remove(location);
            await applicationDbContext.SaveChangesAsync();
            return location;
        }

        public async Task<List<Location>> GetAllLocationAsync()
        {

            var locations = await applicationDbContext.Locations.ToListAsync();
            if (locations is null) return null!;
            return locations;

        }

        public async Task<Location> GetLocationByIdAsync(int locationId)
        {
            var location = await applicationDbContext.Locations.FirstOrDefaultAsync(f => f.Id == locationId);
            if (location is null) return null!;
            return location;
        }

        //public async Task<Location> GetLocationsByIdAsync(int locationId)
        //{
        //    var location = await applicationDbContext.Locations.FirstOrDefaultAsync(f => f.Id == locationId);
        //    if (location is null) return null!;
        //    return location;
        //}

        public async Task<Location> UpdateLocationAsync(Location model)
        {
            var locationToUpdate = await applicationDbContext.Locations.FirstOrDefaultAsync(F => F.Id == model.Id);
            if (locationToUpdate is null) return null!;
            locationToUpdate.Address = model.Address;
            await applicationDbContext.SaveChangesAsync();
            return await applicationDbContext.Locations.FirstOrDefaultAsync(F => F.Id == model.Id)!;
        }
    }
}

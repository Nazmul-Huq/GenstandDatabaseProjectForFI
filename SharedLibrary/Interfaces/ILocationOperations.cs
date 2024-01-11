using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Dtos;


namespace SharedLibrary.Interfaces
{
    // actions can performed on location
    public interface ILocationOperations
    {
        Task<Location> AddLocationAsync(Location model);
        Task<List<Location>> GetAllLocationAsync();
        Task<Location> DeleteLocationAsync(int locationId);
        Task<Location> GetLocationByIdAsync(int locationId);
        Task<Location> UpdateLocationAsync(Location model);
    }
}

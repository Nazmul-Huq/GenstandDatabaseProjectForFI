using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationOperations locationOperations;
        public LocationController(ILocationOperations locationOperations)
        {
            this.locationOperations = locationOperations;
        }

        [HttpPost("Add-Location")]
        public async Task<ActionResult<List<Location>>> AddLocationAsync(Location model)
        {
            var product = await locationOperations.AddLocationAsync(model);
            return Ok(product);
        }

        [HttpGet("Single-Location/{id}")]
        public async Task<ActionResult<Location>> GetSingleLocationAsync(int id)
        {
            var location = await locationOperations.GetLocationByIdAsync(id);
            return Ok(location);
        }

        [HttpGet("Get-All-Locations")]
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()
        {
            var location = await locationOperations.GetAllLocationAsync();
            return Ok(location);
        }

        [HttpPut("Update-Location")]
        public async Task<ActionResult<Location>> UpdateLocationAsync(Location model)
        {
            var product = await locationOperations.UpdateLocationAsync(model);
            return Ok(product);
        }

        [HttpDelete("Delete-Location/{id}")]
        public async Task<ActionResult<Location>> DeleteLocationAsync(int id)
        {
            var location = await locationOperations.DeleteLocationAsync(id);
            return Ok(location);
        }
    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;

namespace GenstandDatabaseProjectForFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenstandController : ControllerBase
    {
        private readonly IGenstandOperations genstandOperations;
        public GenstandController(IGenstandOperations genstandOperations)
        {
            this.genstandOperations = genstandOperations;
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<List<Genstand>>> AddProductAsync(Genstand model)
        {
            var product = await genstandOperations.AddProductAsync(model);
            return Ok(product);
        }

    }
}

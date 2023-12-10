﻿using GenstandDatabaseProjectForFI.Data;
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

        [HttpPost("Add-Genstand")]
        public async Task<ActionResult<List<Genstand>>> AddProductAsync(Genstand model)
        {
            var product = await genstandOperations.AddGenstandAsync(model);
            return Ok(product);
        }

        [HttpGet("Get-All-Genstands")]
        public async Task<ActionResult<List<Genstand>>> GetAllGenstandsAsync()
        {
            var genstands = await genstandOperations.GetAllGenstandsAsync();
            return Ok(genstands);
        }

    }
}
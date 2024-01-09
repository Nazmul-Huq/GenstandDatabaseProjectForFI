using GenstandDatabaseProjectForFI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLibrary.Dtos;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using System.Collections.Generic;
using System.Net;

namespace GenstandDatabaseProjectForFI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenstandController : ControllerBase
    {
        private readonly IGenstandOperations genstandOperations;
        private readonly IFilmOperations filmOperations;
        private readonly IHostEnvironment env;
        public GenstandController(IGenstandOperations genstandOperations, IFilmOperations filmOperations, IHostEnvironment env)
        {
            this.genstandOperations = genstandOperations;
            this.filmOperations = filmOperations;
            this.env = env;
        }

        [HttpPost("Add-Genstand")]
        public async Task<ActionResult<List<Genstand>>> AddProductAsync(GenstandDto model)
        {
            if (model == null) return BadRequest(ModelState);
            Film film = await filmOperations.GetFilmByIdAsync(model.FilmId);
            Genstand genstandToSave = new Genstand
            {
                Name = model.Name,
                Description = model.Description,
                DateOfGenstand = model.DateOfGenstand,
                Size = model.Size,
                PhotoReference = model.PhotoReference,
                Placement = model.Placement,
                Condition = model.Condition,
                Loan = model.Loan,
                //FilmId = model.FilmId,
                Film = film
            };
            var savedGenstand = await genstandOperations.AddGenstandAsync(genstandToSave);
            return Ok(savedGenstand);
        }

        //[HttpPost("Add-Genstand")]
        //public async Task<ActionResult<List<Genstand>>> AddProductAsync(Genstand model)
        //{
        //    var product = await genstandOperations.AddGenstandAsync(model);
        //    return Ok(product);
        //}

        [HttpGet("Get-All-Genstands")]
        public async Task<ActionResult<List<Genstand>>> GetAllGenstandsAsync()
        {
            var genstands = await genstandOperations.GetAllGenstandsAsync();
            return Ok(genstands);
        }


        [HttpDelete("Delete-Genstand/{id}")]
        public async Task<ActionResult<Genstand>> DeleteGenstandAsync(int id)
        {
            var product = await genstandOperations.DeleteGenstandAsync(id);
            return Ok(product);
        }


        [HttpGet("Single-Genstand/{id}")]
        public async Task<ActionResult<List<Genstand>>> GetSingleGenstandAsync(int id)
        {
            var genstand = await genstandOperations.GetGenstandByIdAsync(id);
            return Ok(genstand);
        }

        [HttpPut("Update-Genstand")]
        public async Task<ActionResult<Genstand>> UpdateGenstandAsync(Genstand model)
        {
            var product = await genstandOperations.UpdateGenstandAsync(model);
            return Ok(product);
        }

        [HttpGet("Search-Genstand-By-Name/{searchText}")]
        public async Task<ActionResult<List<Genstand>>> SearchGenstandByNameAsync(string searchText)
        {
            if (searchText == null) { return BadRequest(); }
            var genstands = await genstandOperations.SearchGenstandByNameAsync(searchText);
            return Ok(genstands);
        }

        [HttpPost("Add-Image")]
        public async Task<ActionResult<IList<ImageUploadResult>>> PostFile([FromForm] IEnumerable<IFormFile> files)
        {
            var uploadResult = new ImageUploadResult();
            IList<ImageUploadResult> uploadResults = new List<ImageUploadResult>();




            foreach (var file in files)
            {
                var untrustedFileName = file.FileName;
                //uploadResult.FileName = untrustedFileName;
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);


                if (file.Length == 0)
                {
                    uploadResults.Add(new ImageUploadResult { success = false });
                }
                else
                {
                    try
                    {
                        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        var fullPath = Path.Combine(directoryPath, trustedFileNameForDisplay);

                        // Maek sure the directory is ther bycreating it if it's not exist
                        Directory.CreateDirectory(directoryPath);

                        var trustedFileNameForFileStorage = Path.GetRandomFileName();
                        var path = Path.Combine(env.ContentRootPath,
                            env.EnvironmentName, "unsafe_uploads",
                            trustedFileNameForFileStorage);

                        //await using FileStream fs = new(path, FileMode.Create);
                        await using FileStream fs = new(fullPath, FileMode.Create, FileAccess.Write);
                        await file.CopyToAsync(fs);

                        //logger.LogInformation("{FileName} saved at {Path}", trustedFileNameForDisplay, path);
                        //uploadResult.Uploaded = true;
                        // uploadResult.StoredFileName = trustedFileNameForFileStorage;
                    }
                    catch (IOException ex)
                    {
                        //trustedFileNameForDisplay, ex.Message);
                        //uploadResult.ErrorCode = 3;
                    }

                }

                //if (files.Length == 0) return BadRequest(new ImageUploadResult { success = false });

                //return Ok(new ImageUploadResult { success = true });
                

            }
            return new CreatedResult();
        }
    }
}

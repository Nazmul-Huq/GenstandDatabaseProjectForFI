using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces
{
    public interface IGenstandOperations
    {
        Task<Genstand> AddGenstandAsync(Genstand model);
        Task<List<Genstand>> GetAllGenstandsAsync();
        Task<Genstand> DeleteGenstandAsync(int genstandId);
        Task<Genstand> GetGenstandByIdAsync(int genstandId);
        Task<Genstand> UpdateGenstandAsync(Genstand model);
    }
}

using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using System.Net.Http.Json;

namespace GenstandDatabaseProjectForFI.Client.Services
{
    public class GenstandService: IGenstandOperations
    {
        private readonly HttpClient httpClient;
        public GenstandService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Genstand> AddProductAsync(Genstand model)
        {
            var genstand = await httpClient.PostAsJsonAsync("api/Genstand/Add-Genstand", model);
            var response = await genstand.Content.ReadFromJsonAsync<Genstand>();
            return response!;
        }
    }
}

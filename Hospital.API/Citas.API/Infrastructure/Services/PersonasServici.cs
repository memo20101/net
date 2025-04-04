
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Citas.API.Infrastructure.HttpClients
{
    public class PersonasServici
    {
        private readonly HttpClient _httpClient;

        public PersonasServici(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetPersonaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/personas/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
using Newtonsoft.Json;
using Personas.API.Domain.Entities;
using Personas.API.DTOs;
using Personas.API.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Citas.API.Services
{
    public class PersonasService
    {
        private readonly HttpClient _httpClient;

        public PersonasService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5001/api/personas/"); // URL de Personas.API
        }

        public async Task<PersonaDto> ObtenerPersonaPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonaDto>(json);
        }
    }
}
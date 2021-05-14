using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TPAzure.ViewModels;

namespace TPAzure.HttpServices.Implementations
{
    public class PaisHttpService : IPaisHttpService
    {
        private readonly HttpClient _httpClient;
        public PaisHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> AddAsync(PaisViewModel paisViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(string.Empty, paisViewModel);

            response.EnsureSuccessStatusCode();

            var paisesJsonDeserialized = await response.Content.ReadAsStringAsync();

            var id = int.Parse(paisesJsonDeserialized);

            return id;
        }

        public async Task EditAsync(PaisViewModel paisViewModel)
        {
            var paisesJsonDeserialized = await _httpClient.PutAsJsonAsync($"Pais/{paisViewModel.Id}", paisViewModel);

            paisesJsonDeserialized.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<PaisViewModel>> GetAllAsync(string search)
        {
            
            var paises = await _httpClient.GetFromJsonAsync<IEnumerable<PaisViewModel>>($"Pais/{search}");

            return paises;
        }

        public async Task<PaisViewModel> GetByIdAsync(int id)
        {
            var pais = await _httpClient.GetFromJsonAsync<PaisViewModel>($"Pais/GetById/{id}");

            return pais;
        }

        public async Task RemoveAsync(PaisViewModel paisViewModel)
        {
            var response = await _httpClient.DeleteAsync($"Pais/{paisViewModel.Id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

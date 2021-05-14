using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TPAzure.ViewModels;

namespace TPAzure.HttpServices.Implementations
{
    public class IdiomaHttpService : IIdiomaHttpService
    {
        private readonly HttpClient _httpClient;
        public IdiomaHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> AddAsync(IdiomaViewModel idiomaViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(string.Empty, idiomaViewModel);

            response.EnsureSuccessStatusCode();

            var idiomaJsonDeserialized = await response.Content.ReadAsStringAsync();

            var id = int.Parse(idiomaJsonDeserialized);

            return id;
        }

        public async Task EditAsync(IdiomaViewModel idiomaViewModel)
        {
            var idiomaJsonDeserialized = await _httpClient.PutAsJsonAsync($"Idioma/{idiomaViewModel.Id}", idiomaViewModel);

            idiomaJsonDeserialized.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<IdiomaViewModel>> GetAllAsync(string search)
        {

            var idioma = await _httpClient.GetFromJsonAsync<IEnumerable<IdiomaViewModel>>($"Idioma/{search}");

            return idioma;
        }

        public async Task<IdiomaViewModel> GetByIdAsync(int id)
        {
            var idioma = await _httpClient.GetFromJsonAsync<IdiomaViewModel>($"Idioma/GetById/{id}");

            return idioma;        
        }

        public async Task RemoveAsync(IdiomaViewModel idiomaViewModel)
        {
            var response = await _httpClient.DeleteAsync($"Idioma/{idiomaViewModel.Id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

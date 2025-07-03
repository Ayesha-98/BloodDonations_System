using Entities;
using System.Net.Http.Json;


namespace BusinessLogicLayer
{
    public class DonorService
    {
        private readonly HttpClient _http;

        public DonorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DonorModel>> GetAllDonorsAsync()
        {
            return await _http.GetFromJsonAsync<List<DonorModel>>("api/donor") ?? new();
        }

        public async Task AddDonorAsync(DonorModel donor)
        {
            await _http.PostAsJsonAsync("api/donor", donor);
        }

        public async Task UpdateDonorAsync(DonorModel donor)
        {
            await _http.PutAsJsonAsync($"api/donor/{donor.Id}", donor);
        }

        public async Task DeleteDonorAsync(int id)
        {
            await _http.DeleteAsync($"api/donor/{id}");
        }
    }
}

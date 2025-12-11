using DayCare.Application.DTOs;
using DayCareFRon;
using System.Net.Http.Json;

namespace DayCareFRon.Frontend
{
    public class TutorService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public TutorService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<TutorDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<TutorDto>>($"{_config.ApiBaseUrl}/api/tutor")
                   ?? new List<TutorDto>();
        }

        public async Task<TutorDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<TutorDto>($"{_config.ApiBaseUrl}/api/tutor/{id}");
        }

        public async Task<bool> CreateAsync(TutorDto tutor)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/tutor", tutor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, TutorDto tutor)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/tutor/{id}", tutor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/tutor/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

using DayCare.Application.DTOs;
using DayCareFRon;
using System.Net.Http.Json;

namespace DayCareFRon.Frontend
{
    public class ChildService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public ChildService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<ChildDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<ChildDto>>($"{_config.ApiBaseUrl}/api/child");
            return result ?? new List<ChildDto>();
        }

        public async Task<ChildDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<ChildDto>($"{_config.ApiBaseUrl}/api/child/{id}");
        }

        public async Task<bool> CreateAsync(ChildDto child)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/child", child);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ChildDto child)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/child/{id}", child);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/child/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

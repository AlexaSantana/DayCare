using DayCare.Application.DTOs;
using DayCareFRon;
using System.Net.Http.Json;

namespace DayCareFRon.Frontend
{
    public class ActivityService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public ActivityService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<ActivityDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<ActivityDto>>($"{_config.ApiBaseUrl}/api/activities");
            return result ?? new List<ActivityDto>();
        }

        public async Task<ActivityDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<ActivityDto>($"{_config.ApiBaseUrl}/api/activities/{id}");
        }

        public async Task<bool> CreateAsync(ActivityDto activity)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/activities", activity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ActivityDto activity)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/activities/{id}", activity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/activities/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

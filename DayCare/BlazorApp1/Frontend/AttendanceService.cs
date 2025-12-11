using DayCare.Application.DTOs;
using DayCareFRon;
using System.Net.Http.Json;

namespace DayCareFRon.Frontend
{
    public class AttendanceService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public AttendanceService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<AttendanceDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<AttendanceDto>>($"{_config.ApiBaseUrl}/api/attendance");
            return result ?? new List<AttendanceDto>();
        }

        public async Task<AttendanceDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<AttendanceDto>($"{_config.ApiBaseUrl}/api/attendance/{id}");
        }

        public async Task<bool> CreateAsync(AttendanceDto attendance)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/attendance", attendance);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, AttendanceDto attendance)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/attendance/{id}", attendance);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/attendance/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

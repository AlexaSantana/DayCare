using DayCare.Application.DTOs;
using DayCareFRon;
using System.Net.Http.Json;

namespace DayCareFRon.Frontend
{
    public class MessageService
    {
        private readonly HttpClient _http;
        private readonly ApiConfig _config;

        public MessageService(HttpClient http, ApiConfig config)
        {
            _http = http;
            _config = config;
        }

        public async Task<List<MessageDto>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<MessageDto>>($"{_config.ApiBaseUrl}/api/message");
            return result ?? new List<MessageDto>();
        }

        public async Task<MessageDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<MessageDto>($"{_config.ApiBaseUrl}/api/message/{id}");
        }

        public async Task<bool> CreateAsync(MessageDto message)
        {
            var response = await _http.PostAsJsonAsync($"{_config.ApiBaseUrl}/api/message", message);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, MessageDto message)
        {
            var response = await _http.PutAsJsonAsync($"{_config.ApiBaseUrl}/api/message/{id}", message);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{_config.ApiBaseUrl}/api/message/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
